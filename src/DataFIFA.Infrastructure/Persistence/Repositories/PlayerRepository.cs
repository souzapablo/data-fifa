using DataFIFA.Core.Entities;
using DataFIFA.Infrastructure.Persistence.Repositories.Interfaces;
using DataFIFA.Infrastructure.Persistence.Repositories.Shared;

namespace DataFIFA.Infrastructure.Persistence.Repositories;

public class PlayerRepository : BaseRepository<Player>, IPlayerRepository
{
    public PlayerRepository(DataFifaDbContext context) : base(context)
    {
    }

    public async Task AddLineUpAsync(List<Player> lineUp)
    {
        await Context.Players.AddRangeAsync(lineUp);
        await Context.SaveChangesAsync();
    }
}