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
    
    public async Task<List<User>> ListAll() 
    {
        return await _dbContext.Users
            .ToListAsync();
    }

    public async Task<User?> GetUserById(Guid id)
    {
        return await _dbContext.Users
            .SingleOrDefaultAsync(u => u.Id == id);
    }

    public async Task AddNewUser(User user)
    {
        await _dbContext.Users.AddAsync(user);
        await _dbContext.SaveChangesAsync();
    }

    public async Task<bool> IsEmailRegistered(string email)
    {
        var user = await _dbContext.Users.SingleOrDefaultAsync(x => x.Email == email);

        return user is not null;
    }
}