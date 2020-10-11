using System.Linq;
using System.Collections.Generic;
using Npgsql;
using System;
using PokerLeaderboard.BusinessLogic;

namespace PokerLeaderboard.Infrastructure
{
    public class LookupCountryData
    {
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
                        LookupCountry lookupCountry = new LookupCountry()
                        {
                            Id = id,
                            ExternalId = externalId,
                            FullName = fullName,
                            Abbreviation = abbreviation
                        };
                        result.Add(lookupCountry);
                    }
                }
            }
            return result;
        }
    }
}