using DataFIFA.Core.Entities.Shared;

namespace DataFIFA.Core.Entities
{
    public class Career : BaseEntity
    {
        public Career(Guid userId, string managerName)
        {
            UserId = userId;
            ManagerName = managerName;

            Teams = new ();
        }

        public Guid UserId { get; private set; }
        public string ManagerName { get; private set; }
        public List<Team> Teams { get; private set; }
    }
}