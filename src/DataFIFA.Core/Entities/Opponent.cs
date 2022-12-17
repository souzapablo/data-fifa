using DataFIFA.Core.Entities.Shared;

namespace DataFIFA.Core.Entities
{
    public class Opponent : BaseEntity
    {
        public Opponent(string name, string stadium)
        {
            Name = name;
            Stadium = stadium;
        }

        public string Name { get; private set; }
        public string Stadium { get; private set; }
    }
}