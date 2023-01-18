using DataFIFA.Core.Entities;
using DataFIFA.Infrastructure.Persistence.Repositories.Interfaces.Shared;

namespace DataFIFA.Infrastructure.Persistence.Repositories.Interfaces;

public interface IPlayerRepository : IBaseRepository<Player>
{
    Task AddLineUpAsync(List<Player> lineUp);
}