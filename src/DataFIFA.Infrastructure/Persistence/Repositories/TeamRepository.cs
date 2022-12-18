using DataFIFA.Core.Entities;
using DataFIFA.Infrastructure.Persistence.Repositories.Interfaces;
using DataFIFA.Infrastructure.Persistence.Repositories.Shared;

namespace DataFIFA.Infrastructure.Persistence.Repositories;

public class TeamRepository : BaseRepository<Team>, ITeamRepository
{
    public TeamRepository(DataFifaDbContext context) : base(context)
    {
    }
}