using DataFIFA.Core.Entities;
using DataFIFA.Infrastructure.Persistence.Repositories.Interfaces.Shared;

namespace DataFIFA.Infrastructure.Persistence.Repositories.Interfaces;

public interface IUserRepository : IBaseRepository<User>
{
    Task<bool> IsEmailRegistered(string email);
    Task<List<User>> ListUsersWithCurrentTeam(Guid id);
    Task<User?> GetUserByIdWithCurrentTeam(Guid id);
}