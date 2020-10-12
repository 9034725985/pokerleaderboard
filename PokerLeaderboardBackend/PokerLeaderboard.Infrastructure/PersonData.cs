using System.Linq;
using System.Collections.Generic;
using Npgsql;
using System;
using PokerLeaderboard.BusinessLogic;
using System.Threading.Tasks;

namespace PokerLeaderboard.Infrastructure
{
    public class PersonData
    {
        public static async void AddPerson(string connectionString, string fullName, decimal winnings, string countryAbbreviation)
        {
            await using var conn = new NpgsqlConnection(connectionString: connectionString);
            await conn.OpenAsync();
            try
            {
                await using (var cmd = new NpgsqlCommand(@"
                    insert into person(full_name, winnings, country)
                    select person_name, winnings, external_id
                    from 
                    (
                        values 
                        ('@fullName', @winnings::numeric)
                    ) as person (person_name, winnings)
                    cross join (select external_id from lookup_country where abbreviation = '@abbreviation') c;", conn))
                {
                    cmd.Parameters.AddWithValue("fullName", fullName);
                    cmd.Parameters.AddWithValue("winnings", winnings);
                    cmd.Parameters.AddWithValue("abbreviation", countryAbbreviation);
                    await cmd.ExecuteNonQueryAsync();
                }
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
            }
        }
        public static async Task<List<Person>> Get(string connectionString)
        {
            List<Person> result = new List<Person>();
            await using var conn = new NpgsqlConnection(connectionString);
            await conn.OpenAsync();
            await using (var cmd = new NpgsqlCommand(@"select p.id, p.external_id, p.full_name, p.winnings, c.id, c.external_id, c.full_name, c.abbreviation from person p inner join lookup_country c on p.country = c.external_id;", conn))
            {
                await using (var reader = cmd.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        int personId = reader.GetInt32(0);
                        Guid personExternalId = new Guid(reader.GetString(1));
                        string personFullName = reader.GetString(2);
                        decimal winnings = reader.GetDecimal(3);

                        int countryId = reader.GetInt32(4);
                        Guid countryExternalId = new Guid(reader.GetString(5));
                        string countryFullName = reader.GetString(6);
                        string countryAbbreviation = reader.GetString(7);
                        LookupCountry country = new LookupCountry
                        (
                            id: countryId,
                            externalId: countryExternalId,
                            fullName: countryFullName,
                            abbreviation: countryAbbreviation
                        );

                        Person person = new Person
                        (
                            id: personId,
                            externalId: personExternalId,
                            fullName: personFullName,
                            winnings: winnings,
                            country: country
                        );
                        result.Add(person);
                    }
                }
            }
            return result;
        }
    }
}