using DataFIFA.Core.Entities;
using DataFIFA.Infrastructure.Persistence.Repositories.Interfaces.Shared;

namespace DataFIFA.Infrastructure.Persistence.Repositories.Interfaces;

public interface IUserRepository : IBaseRepository<User>
{
    Task<bool> IsEmailRegistered(string email);
    Task<User?> GetUserByIdWithCurrentTeam(Guid id);
    Task<User?> GetUserByNameAndPassword(string name, string password);
}