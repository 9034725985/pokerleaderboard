using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using PokerLeaderboard.BusinessLogic;
using PokerLeaderboard.Infrastructure;

namespace PokerLeaderboard.Console
{
    class Program
    {
        static void Main(string[] args)
        {
            string connectionString = "Host=balarama.db.elephantsql.com;Port=5432;Username=xukiiogf;Password=REkQDxhkxXdSd9Yj7gbj75ovitfPxr7k;Database=xukiiogf;Integrated Security=true;Pooling=true;Timeout=30";
            MainAsync(connectionString: connectionString).GetAwaiter().GetResult();
        }

        static async Task MainAsync(string connectionString)
        {
            for (int i = 0; i < 3; i++)
            {
                string fullName = Guid.NewGuid().ToString();
                string abbreviation = fullName.Substring(fullName.Length - 10);
                decimal winnings = 10;
                string countryAbbreviation = "USA";
                // LookupCountryData.AddLookupCountry(connectionString: connectionString, fullName: fullName, abbreviation: abbreviation);
                PersonData.AddPerson(connectionString: connectionString, fullName: fullName, winnings: winnings, countryAbbreviation: countryAbbreviation);
            }

            // List<LookupCountry> countries = await LookupCountryData.Get(connectionString);
            // foreach (LookupCountry country in countries)
            // {
            //     System.Console.WriteLine($"Country Name: {country.FullName}. Abbreviation: {country.Abbreviation}.");
            // }

            List<Person> persons = await PersonData.Get(connectionString);
            foreach (Person person in persons)
            {
                System.Console.WriteLine($"Person Name: {person.FullName}. Winnings: {person.Winnings}. Country: {person.Country.Abbreviation}");
            }
        }
    }
}
