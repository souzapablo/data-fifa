using DataFIFA.Core.Entities.Shared;
using DataFIFA.Core.Enums;

namespace DataFIFA.Core.Entities
{
    public class Match : BaseEntity
    {
        public Match(Guid opponentId, string lineUp, string result, bool isHome, Competition competition)
        {
            OpponentId = opponentId;
            LineUp = lineUp;
            Result = result;
            IsHome = isHome;
            Competition = competition;

            Goals = new ();
        }

        public Guid OpponentId { get; private set; }
        public string LineUp { get; private set; }
        public List<Goal> Goals { get; private set; }
        public string Result { get; private set; }
        public bool IsHome { get; private set; }
        public Competition Competition { get; private set; }
    }
}