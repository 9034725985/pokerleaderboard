using System;

namespace PokerLeaderboard.BusinessLogic
{
    public class LookupCountry
    {
        public int Id { get; set; }
        public Guid ExternalId { get; set; }
        public string FullName { get; set; }
        public string Abbreviation { get; set; }
    }
}
