using System.Linq.Expressions;
using DataFIFA.Core.Entities.Shared;
using DataFIFA.Infrastructure.Persistence.Repositories.Interfaces.Shared;
using Microsoft.EntityFrameworkCore;

namespace DataFIFA.Infrastructure.Persistence.Repositories.Shared;

public class BaseRepository<T> : IBaseRepository<T> where T : BaseEntity
{
    protected readonly DataFifaDbContext Context;

    protected BaseRepository(DataFifaDbContext context)
    {
        Context = context;
    }
    
    public async Task<List<T>> ListAllAsync(params Expression<Func<T, object?>>[]? includes)
    {
        var query = Context.Set<T>().AsQueryable();

        if (includes != null)
            query = includes.Aggregate(query, (current, include) => current.Include(include));

        return await query.Where(x => x.IsActive).ToListAsync();
    }

    public async Task<T?> GetByIdAsync(Guid id, params Expression<Func<T, object?>>[]? includes)
    {
        var query = Context.Set<T>().AsQueryable();

        if (includes != null)
            query = includes.Aggregate(query, (current, include) => current.Include(include));

        return await query.Where(x => x.Id.Equals(id)).SingleOrDefaultAsync();
    }

    public async Task AddAsync(T entity)
    {
        await Context.Set<T>().AddAsync(entity);

        await Context.SaveChangesAsync();
    }
    
    public async Task UpdateAsync(T entity)
    {
        entity.Update();
        Context.Entry(entity).State = EntityState.Modified;
        await Context.SaveChangesAsync();
    }
    
}