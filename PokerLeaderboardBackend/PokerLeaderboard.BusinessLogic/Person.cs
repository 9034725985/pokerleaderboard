using System;

namespace PokerLeaderboard.BusinessLogic
{
    public class Person
    {
        public int Id { get; private set; }
        public Guid ExternalId { get; private set; }
        public string FullName { get; set; }
        public decimal Winnings { get; set; }
        public LookupCountry Country { get; set; }
        public Person(int id, Guid externalId, string fullName, decimal winnings, LookupCountry country) 
        {
            Id = id;
            ExternalId = externalId;
            FullName = fullName;
            Winnings = winnings;
            Country = country;
        }
    }
}
