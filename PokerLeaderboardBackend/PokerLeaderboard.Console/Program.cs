using System.Collections.Generic;
using PokerLeaderboard.Infrastructure;

namespace PokerLeaderboard.Console
{
    class Program
    {
        static void Main(string[] args)
        {
            string connectionString = "Host=balarama.db.elephantsql.com;Port=5432;Username=xukiiogf;Password=REkQDxhkxXdSd9Yj7gbj75ovitfPxr7k;Database=xukiiogf;Integrated Security=true;Pooling=true;Timeout=30";

            LookupCountry lookupCountry = new LookupCountry();
            List<string> countries = lookupCountry.GetAllLookupCountryNames(connectionString);
            foreach (string country in countries)
            {
                System.Console.WriteLine(country);
            }
        }
    }
}
