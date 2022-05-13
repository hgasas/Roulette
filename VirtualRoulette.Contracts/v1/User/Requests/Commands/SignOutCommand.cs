using MediatR;
using VirtualRoulette.Contracts.v1.User.Responses;

namespace VirtualRoulette.Contracts.v1.User.Requests.Commands;

public class SignOutCommand : IRequest<SignOutResponse>
{
    public long UserId { get; set; }
}