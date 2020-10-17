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
            Run(connectionString: connectionString);
        }
        static void Run(string connectionString)
        {
            MainAsync(connectionString: connectionString).GetAwaiter().GetResult();
        }

        static async Task MainAsync(string connectionString)
        {
            string fullName = "Kus";
            decimal winnings = 200000M;
            string countryAbbreviation = "USA";
            PersonData.AddPerson(connectionString: connectionString, fullName: fullName, winnings: winnings, countryAbbreviation: countryAbbreviation);

            List<Person> persons = await PersonData.Get(connectionString);
            foreach (Person person in persons)
            {
                System.Console.WriteLine($"Person Name: {person.FullName}. Winnings: {person.Winnings.ToString(System.Globalization.CultureInfo.InvariantCulture)}. Country: {person.Country.Abbreviation}");
                // Delete persons 
                PersonData.DeletePerson(connectionString: connectionString, externalId: person.ExternalId);
            }
        }
    }
}
