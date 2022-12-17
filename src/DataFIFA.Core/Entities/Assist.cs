using DataFIFA.Core.Entities.Shared;

namespace DataFIFA.Core.Entities
{
    public class Assist : BaseEntity
    {
        public Assist(Guid goalId, Guid playerId)
        {
            GoalId = goalId;
            PlayerId = playerId;    
        }

        public Guid GoalId { get; private set; }
        public Guid PlayerId { get; private set; }
    }
}