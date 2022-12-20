using DataFIFA.Core.Entities;
using DataFIFA.Infrastructure.Persistence.Repositories.Interfaces;
using DataFIFA.Infrastructure.Persistence.Repositories.Shared;
using Microsoft.EntityFrameworkCore;

namespace DataFIFA.Infrastructure.Persistence.Repositories;

public class UserRepository : BaseRepository<User>, IUserRepository
{
    public UserRepository(DataFifaDbContext context) : base(context)
    {
        
    }
    
    public async Task<bool> IsEmailRegistered(string email)
    {
        var user = await Context.Users
            .SingleOrDefaultAsync(x => x.Email == email);

        return user is not null;
    }

    public Task<List<User>> ListUsersWithCurrentTeam(Guid id)
    {
        return Context.Users
            .Include(x => x.Careers)
            .ThenInclude(x => x.CurrentTeam)
            .ToListAsync();
    }

    public Task<User?> GetUserByIdWithCurrentTeam(Guid id)
    {
        return Context.Users
            .Include(x => x.Careers)
            .ThenInclude(x => x.CurrentTeam)
            .SingleOrDefaultAsync(x => x.Id == id);
    }
}