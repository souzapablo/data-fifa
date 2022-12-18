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
        var user = await Context.Users.SingleOrDefaultAsync(x => x.Email == email);

        return user is not null;
    }
}