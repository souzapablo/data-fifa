using DataFIFA.Core.Entities.Shared;
using DataFIFA.Core.Enums;

namespace DataFIFA.Core.Entities
{
    public class Player : BaseEntity
    {
        public Player(Guid teamId, string firstName, string lastName, int overall, int shirtNumber, Situation situation, Position position,
         int age)
        {
            TeamId = teamId;
            FirstName = firstName;
            LastName = lastName;
            Overall = overall;
            ShirtNumber = shirtNumber;
            Situation = situation;
            Position = position;
            Age = age;
        }
    
        public Guid TeamId { get; private set; }
        public Team Team { get; private set; }
        public string FirstName { get; private set; }
        public string LastName { get; private set; }
        public int Overall { get; private set; }
        public int ShirtNumber { get; private set; }
        public Situation Situation { get; private set; }
        public Position Position { get; private set; }
        public int Age { get; private set; }
    }
}