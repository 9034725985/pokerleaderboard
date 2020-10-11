using System.Collections.Generic;
using Npgsql;

namespace PokerLeaderboard.Infrastructure
{
    public class LookupCountry
    {
        public List<string> GetAllLookupCountryNames(string connectionString)
        {
            List<string> result = new List<string>();
            using var conn = new NpgsqlConnection(connectionString);
            conn.Open();
            using (var cmd = new NpgsqlCommand("SELECT full_name FROM lookup_country", conn))
            {
                using (var reader = cmd.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        result.Add(reader.GetString(0));
                    }
                }
            }
            return result;
        }
    }
}