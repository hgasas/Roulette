using System.Linq.Expressions;
using VirtualRoulette.Domain.Common;

namespace VirtualRoulette.Application.RepositoryInterfaces;

public interface IRepository<T> where T : AggregateRoot
{
    Task<List<T>> GetAllAsync();
    
    Task<T> GetByIdAsync(long id);

    Task<List<T>> GetByQueryAsync(Expression<Func<T, bool>> expression);
    
    Task CreateAsync(T entity);
    
    Task<bool> UpdateAsync(T entity);
    
    Task<bool> DeleteAsync(T entity);    
}