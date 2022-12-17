using DataFIFA.Core.Entities.Shared;

namespace DataFIFA.Core.Entities
{
    public class Team : BaseEntity
    {
        public Team(Guid careerId, string name, string stadium)
        {
            CareerId = careerId;
            Name = name;
            Stadium = stadium;

            Players = new List<Player>();
            Matches = new List<Match>();
            Transfers = new List<Transfer>();
        }

        public Guid CareerId { get; private set; }
        public string Name { get; private set; }
        public string Stadium { get; private set; }
        public List<Player> Players { get; private set; }
        public List<Match> Matches { get; private set; }
        public List<Transfer> Transfers { get; private set; }
    }
}