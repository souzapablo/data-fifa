using DataFIFA.Core.Entities;
using DataFIFA.Infrastructure.Persistence.Repositories.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace DataFIFA.Infrastructure.Persistence.Repositories;

public class UserRepository : IUserRepository
{
    private readonly DataFifaDbContext _dbContext;

    public UserRepository(DataFifaDbContext dbContext)
    {
        _dbContext = dbContext;
    }
    
    public Task<List<User>> ListAll() 
    {
        return _dbContext.Users
            .ToListAsync();
    }

    public Task<User?> GetUserById(Guid id)
    {
        return _dbContext.Users
            .SingleOrDefaultAsync(u => u.Id == id);
    }
}