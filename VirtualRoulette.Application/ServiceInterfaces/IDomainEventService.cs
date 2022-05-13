using VirtualRoulette.Domain.Common;

namespace VirtualRoulette.Application.ServiceInterfaces;

public interface IDomainEventService
{
    Task Publish(IDomainEvent domainEvent);
}