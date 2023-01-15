using DataFIFA.Core.Entities;
using DataFIFA.Infrastructure.Persistence.Repositories.Interfaces.Shared;

namespace DataFIFA.Infrastructure.Persistence.Repositories.Interfaces;

public interface ICareerRepository : IBaseRepository<Career>
{
    Task<List<Career>?> GetByUserId(Guid userId);
}