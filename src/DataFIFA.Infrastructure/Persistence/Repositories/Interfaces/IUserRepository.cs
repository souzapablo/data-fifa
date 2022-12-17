using DataFIFA.Core.Entities;

namespace DataFIFA.Infrastructure.Persistence.Repositories.Interfaces;

public interface IUserRepository
{
    Task<List<User>> ListAll();
    Task<User?> GetUserById(Guid id);
    Task AddNewUser(User user);
    Task<bool> IsEmailRegistered(string email);
}