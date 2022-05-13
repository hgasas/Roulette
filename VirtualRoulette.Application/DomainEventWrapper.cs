using MediatR;
using VirtualRoulette.Domain.Common;

namespace VirtualRoulette.Application;

//Wrapper class for holding domain event. Directly using Domain Event was not good idea
public class DomainEventWrapper<TDomainEvent> : INotification
    where TDomainEvent : DomainEvent
{
    public TDomainEvent DomainEvent { get; }
    
    public DomainEventWrapper(TDomainEvent domainEvent)
    {
        DomainEvent = domainEvent;
    }
}