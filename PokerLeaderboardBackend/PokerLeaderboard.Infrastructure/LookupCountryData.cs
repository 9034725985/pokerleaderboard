using System.Linq;
using System.Collections.Generic;
using Npgsql;
using System;
using PokerLeaderboard.BusinessLogic;

namespace PokerLeaderboard.Infrastructure
{
    public class LookupCountryData
    {
        public static void AddLookupCountry(string connectionString, string fullName, string abbreviation)
        {
            using var conn = new NpgsqlConnection(connectionString);
            conn.Open();
            using (var cmd = new NpgsqlCommand("INSERT INTO lookup_country (full_name, abbreviation) VALUES (@full_name, @abbreviation)", conn))
            {
                cmd.Parameters.AddWithValue("full_name", fullName);
                cmd.Parameters.AddWithValue("abbreviation", abbreviation);
                cmd.ExecuteNonQuery();
            }
        }
        public static List<LookupCountry> GetAllLookupCountries(string connectionString)
        {
            List<LookupCountry> result = new List<LookupCountry>();
            using var conn = new NpgsqlConnection(connectionString);
            conn.Open();
            using (var cmd = new NpgsqlCommand("SELECT id, external_id, full_name, abbreviation FROM lookup_country", conn))
            {
                using (var reader = cmd.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        // result.Add(reader.GetString(0));
                        int id = reader.GetInt32(0);
                        Guid externalId = new Guid(reader.GetString(1));
                        string fullName = reader.GetString(2);
                        string abbreviation = reader.GetString(3);
                        LookupCountry lookupCountry = new LookupCountry
                        (
                            id: id,
                            externalId: externalId,
                            fullName: fullName,
                            abbreviation: abbreviation
                        );
                        result.Add(lookupCountry);
                    }
                }
            }
            return result;
        }
    }
}