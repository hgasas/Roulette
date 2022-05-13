using MediatR;
using VirtualRoulette.Contracts.v1.User.Responses;

namespace VirtualRoulette.Contracts.v1.User.Requests.Commands;

public class SignInCommand : IRequest<SignInResponse>
{
    public string Username { get; set; }
    
    public string Password { get; set; }
}