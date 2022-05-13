using MediatR;
using VirtualRoulette.Domain.Common;

namespace VirtualRoulette.Application;

public class DomainEventWrapper<TDomainEvent> : INotification
    where TDomainEvent : DomainEvent
{
    public TDomainEvent DomainEvent { get; }
    
    public DomainEventWrapper(TDomainEvent domainEvent)
    {
        DomainEvent = domainEvent;
    }
}