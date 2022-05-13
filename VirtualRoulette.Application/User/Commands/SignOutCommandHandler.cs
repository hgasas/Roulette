using MediatR;
using VirtualRoulette.Contracts.v1.User.Requests.Commands;
using VirtualRoulette.Contracts.v1.User.Responses;

namespace VirtualRoulette.Application.User.Commands;

public class SignOutCommandHandler : IRequestHandler<SignOutCommand, SignOutResponse>
{
    public Task<SignOutResponse> Handle(SignOutCommand request, CancellationToken cancellationToken)
    {
        throw new NotImplementedException();
    }
}