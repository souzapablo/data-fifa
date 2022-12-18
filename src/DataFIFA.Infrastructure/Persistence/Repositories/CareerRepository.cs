using DataFIFA.Core.Entities;
using DataFIFA.Infrastructure.Persistence.Repositories.Interfaces;
using DataFIFA.Infrastructure.Persistence.Repositories.Shared;

namespace DataFIFA.Infrastructure.Persistence.Repositories;

public class CareerRepository : BaseRepository<Career>, ICareerRepository
{
    public CareerRepository(DataFifaDbContext context) : base(context)
    {
    }
}