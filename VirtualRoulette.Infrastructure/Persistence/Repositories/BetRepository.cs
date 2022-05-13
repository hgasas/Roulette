using VirtualRoulette.Application.RepositoryInterfaces;
using VirtualRoulette.Application.ServiceInterfaces;
using VirtualRoulette.Domain.Entities;

namespace VirtualRoulette.Infrastructure.Persistence.Repositories;

public class BetRepository : RepositoryBase<Bet>, IBetRepository
{
    public BetRepository(AppDbContext dbContext, IDomainEventService domainEventService)
        : base(dbContext, domainEventService)
    {
    }
}