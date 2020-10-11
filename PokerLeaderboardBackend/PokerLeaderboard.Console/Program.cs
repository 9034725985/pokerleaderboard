using System.Collections.Generic;
using PokerLeaderboard.BusinessLogic;
using PokerLeaderboard.Infrastructure;

namespace PokerLeaderboard.Console
{
    class Program
    {
        static void Main(string[] args)
        {
            string connectionString = "Host=balarama.db.elephantsql.com;Port=5432;Username=xukiiogf;Password=REkQDxhkxXdSd9Yj7gbj75ovitfPxr7k;Database=xukiiogf;Integrated Security=true;Pooling=true;Timeout=30";

            List<LookupCountry> countries = LookupCountryData.GetAllLookupCountries(connectionString);
            foreach (LookupCountry country in countries)
            {
                System.Console.WriteLine($"Country Name: {country.FullName}. Abbreviation: {country.Abbreviation}.");
            }
        }
    }
}
