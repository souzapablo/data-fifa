using DataFIFA.Core.Entities.Shared;

namespace DataFIFA.Core.Entities
{
    public class Career : BaseEntity
    {
        public Career(Guid userId, string managerName)
        {
            UserId = userId;
            ManagerName = managerName;

            Teams = new List<Team>();
        }

        public Guid UserId { get; private set; }
        public User User { get; private set; }
        public Guid? CurrentTeamId { get; private set; }
        public Team?  CurrentTeam { get; private set; }
        public string ManagerName { get; private set; }
        public List<Team> Teams { get; private set; }

        public void AddTeam(Guid teamId)
        {
            CurrentTeamId = teamId;
            LastUpdate = DateTime.Now;
        }
        
    }
}