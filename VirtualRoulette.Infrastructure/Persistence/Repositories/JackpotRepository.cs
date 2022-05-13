using VirtualRoulette.Application.RepositoryInterfaces;
using VirtualRoulette.Application.ServiceInterfaces;
using VirtualRoulette.Domain.Entities;

namespace VirtualRoulette.Infrastructure.Persistence.Repositories;

public class JackpotRepository : RepositoryBase<Jackpot>, IJackpotRepository
{
    public JackpotRepository(AppDbContext dbContext, IDomainEventService domainEventService)
        : base(dbContext, domainEventService)
    {
    }
}