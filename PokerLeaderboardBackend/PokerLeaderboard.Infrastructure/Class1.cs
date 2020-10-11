using System;
using Npgsql;

namespace PokerLeaderboard.Infrastructure
{
    public class Class1
    {
        void Print(string connectionString)
        {
            // postgres://xukiiogf:REkQDxhkxXdSd9Yj7gbj75ovitfPxr7k@balarama.db.elephantsql.com:5432/xukiiogf
            var connString = "Host=balarama.db.elephantsql.com;Port=5432;Username=xukiiogf;Password=REkQDxhkxXdSd9Yj7gbj75ovitfPxr7k;Database=xukiiogf;Integrated Security=true;Pooling=true;Timeout=30";

            using var conn = new NpgsqlConnection(connString);
            conn.Open();

            // Insert some data
            using (var cmd = new NpgsqlCommand("INSERT INTO lookup_country (full_name, abbreviation) VALUES (@full_name, @abbreviation)", conn))
            {
                cmd.Parameters.AddWithValue("full_name", "Nepal");
                cmd.Parameters.AddWithValue("abbreviation", "NP");
                cmd.ExecuteNonQuery();
            }

            // Retrieve all rows
            using (var cmd = new NpgsqlCommand("SELECT full_name FROM lookup_country", conn))
            using (var reader = cmd.ExecuteReader())
                while (reader.Read())
                    System.Console.WriteLine(reader.GetString(0));
        }
    }
}
