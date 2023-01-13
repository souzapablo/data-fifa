using System.Linq.Expressions;

namespace DataFIFA.Infrastructure.Persistence.Repositories.Interfaces.Shared;

public interface IBaseRepository<T>
{
    Task<List<T>> ListAllAsync(params Expression<Func<T, object?>>[]? includes);
    Task<T?> GetByIdAsync(Guid id, params Expression<Func<T, object?>>[]? includes);
    Task AddAsync(T entity);
    Task UpdateAsync(T entity);
    Task Delete(T entity);
}