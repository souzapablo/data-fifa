using DataFIFA.Core.Entities.Shared;

namespace DataFIFA.Core.Entities
{
    public class Goal : BaseEntity
    {
        public Goal(Guid playerId, Guid assistId, Guid matchId)
        {
            PlayerId = playerId;
            AssistId = assistId;
            MatchId = matchId;
        }

        public Guid PlayerId { get; private set; }
        public Guid AssistId { get; private set; }
        public Guid MatchId { get; private set; }
    }
}