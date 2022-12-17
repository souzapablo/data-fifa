using DataFIFA.Core.Entities.Shared;
using DataFIFA.Core.Enums;

namespace DataFIFA.Core.Entities
{
    public class Player : BaseEntity
    {
        public Player(Guid teamId, string name, int overall, int shirtNumber, Situation situation, Position position,
         int age)
        {
            TeamId = teamId;
            Name = name;
            Overall = overall;
            ShirtNumber = shirtNumber;
            Situation = situation;
            Position = position;
            Age = age;
        }

        public Guid TeamId { get; private set; }
        public string Name { get; private set; }
        public int Overall { get; private set; }
        public int ShirtNumber { get; private set; }
        public Situation Situation { get; private set; }
        public Position Position { get; private set; }
        public int Age { get; private set; }
    }
}