using MediatR;
using VirtualRoulette.Common;
using VirtualRoulette.Domain.Exceptions;

namespace VirtualRoulette.Infrastructure;

//Wrapper class for mediator, which handles all the exceptions and returns the response
public class MediatorWrapper
{
    private readonly IMediator _mediator;

    public MediatorWrapper(IMediator mediator)
    {
        _mediator = mediator;
    }
    
    public async Task<Response<TResponse>> Send<TResponse>(IRequest<Response<TResponse>> request) where TResponse : class
    {
        try
        {
            return await _mediator.Send(request);
        }
        catch(DomainException ex)
        {
            return ResponseHelper<TResponse>.GetResponse(StatusCode.BadRequest, ex.Message);
        }
        catch(Exception ex)
        {
            return ResponseHelper<TResponse>.GetResponse(StatusCode.InternalServerError);
        }
    }
    
    public async Task Publish<TNotification>(TNotification notification) where TNotification : INotification
    {
        await _mediator.Publish(notification);
    }
}