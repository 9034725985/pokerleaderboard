using System;

namespace PokerLeaderboard.BusinessLogic
{
    public class LookupCountry
    {
        public int Id { get; private set; }
        public Guid ExternalId { get; private set; }
        public string FullName { get; set; }
        public string Abbreviation { get; set; }
        public LookupCountry(int id, Guid externalId, string fullName, string abbreviation) 
        {
            Id = id;
            ExternalId = externalId;
            FullName = fullName;
            Abbreviation = abbreviation;
        }
    }
}
