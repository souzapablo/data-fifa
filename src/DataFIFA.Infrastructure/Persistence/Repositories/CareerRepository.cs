using DataFIFA.Core.Entities;
using DataFIFA.Infrastructure.Persistence.Repositories.Interfaces;
using DataFIFA.Infrastructure.Persistence.Repositories.Shared;
using Microsoft.EntityFrameworkCore;

namespace DataFIFA.Infrastructure.Persistence.Repositories;

public class CareerRepository : BaseRepository<Career>, ICareerRepository
{
    public CareerRepository(DataFifaDbContext context) : base(context)
    {
    }

    public async Task<List<Career>?> GetByUserId(Guid userId)
    {
        return await Context.Careers
            .Where(x => x.UserId == userId)
            .ToListAsync();
    }
}