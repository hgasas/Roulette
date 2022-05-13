using System.Linq.Expressions;
using Microsoft.EntityFrameworkCore;
using VirtualRoulette.Application.RepositoryInterfaces;
using VirtualRoulette.Application.ServiceInterfaces;
using VirtualRoulette.Domain.Common;

namespace VirtualRoulette.Infrastructure.Persistence.Repositories;

public class RepositoryBase<T> : IRepository<T> where T : AggregateRoot
{
    private readonly AppDbContext _dbContext;
    private readonly IDomainEventService _domainEventService;

    public RepositoryBase(AppDbContext dbContext, IDomainEventService domainEventService)
    {
        _dbContext = dbContext;
        _domainEventService = domainEventService;
    }

    public async Task<List<T>> GetAllAsync()
    {
        return await _dbContext.Set<T>().ToListAsync();
    }

    public async Task<T> GetByIdAsync(long id)
    {
        return await _dbContext.Set<T>().FirstOrDefaultAsync(e => e.Id == id);
    }

    public Task<List<T>> GetByQueryAsync(Expression<Func<T, bool>> expression)
    {
        return _dbContext.Set<T>().Where(expression).ToListAsync();
    }

    public async Task CreateAsync(T entity)
    {
        await _dbContext.Set<T>().AddAsync(entity);

        await DispatchEvents(entity);
    }

    private async Task DispatchEvents(T entity)
    {
        foreach (var domainEvent in entity.NotCommittedEvents)
        {
            await _domainEventService.PublishAsync(domainEvent);
        }
    }

    public async Task<bool> UpdateAsync(T entity)
    {
        while (true)
        {
            try
            {
                _dbContext.Set<T>().Update(entity);
                var affectedRowsCount = await _dbContext.SaveChangesAsync();
                
                var isUpdated = affectedRowsCount > 0;
                if (!isUpdated)
                {
                    return false;
                }
                
                await DispatchEvents(entity);

                return true;
            }
            catch (DbUpdateConcurrencyException exception)
            {
                await exception.Entries.Single().ReloadAsync();
            }
        }
    }

    public async Task<bool> DeleteAsync(T entity)
    {
        _dbContext.Set<T>().Remove(entity);
        var affectedRowsCount = await _dbContext.SaveChangesAsync();
        
        var isDeleted = affectedRowsCount > 0;
        if (!isDeleted)
        {
            return false;
        }
        
        await DispatchEvents(entity);
        return true;
    }
}