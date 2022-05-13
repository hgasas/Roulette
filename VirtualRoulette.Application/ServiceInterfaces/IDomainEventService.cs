using VirtualRoulette.Domain.Common;

namespace VirtualRoulette.Application.ServiceInterfaces;

public interface IDomainEventService
{
    /// <summary>
    /// Publishes the specified domain event.
    /// </summary>
    /// <param name="domainEvent"></param>
    /// <returns></returns>
    Task PublishAsync(IDomainEvent domainEvent);
}