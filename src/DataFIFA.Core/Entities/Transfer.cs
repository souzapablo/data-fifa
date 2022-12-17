using DataFIFA.Core.Entities.Shared;

namespace DataFIFA.Core.Entities
{
    public class Transfer : BaseEntity
    {
        public Transfer(Guid teamId, Guid playerId, Guid originId, Guid destinationId, decimal price, string season, bool isLoan)
        {
            TeamId = teamId;
            PlayerId = playerId;
            OriginId = originId;
            DestinationId = destinationId;
            Price = price;
            Season = season;
        }

        public Guid TeamId { get; private set; }
        public Guid PlayerId { get; private set; }
        public Guid OriginId { get; private set; }
        public Guid DestinationId { get; private set; }
        public decimal Price { get; private set; }
        public string Season { get; private set; }
        public bool IsLoan { get; private set; }
    }
}