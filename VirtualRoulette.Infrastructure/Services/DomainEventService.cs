using MediatR;
using VirtualRoulette.Application;
using VirtualRoulette.Application.ServiceInterfaces;
using VirtualRoulette.Domain.Common;

namespace VirtualRoulette.Infrastructure.Services;

public class DomainEventService : IDomainEventService
{
    private readonly IMediator _mediator;

    public DomainEventService(IMediator mediator)
    {
        _mediator = mediator;
    }

    public async Task Publish(IDomainEvent domainEvent)
    {
        domainEvent.Commit();
        
        var notification = Activator.CreateInstance(
            typeof(DomainEventWrapper<>).MakeGenericType(domainEvent.GetType()), domainEvent) as INotification;

        await _mediator.Publish(notification);
    }
}