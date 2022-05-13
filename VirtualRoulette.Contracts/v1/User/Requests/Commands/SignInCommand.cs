using MediatR;
using VirtualRoulette.Common;
using VirtualRoulette.Contracts.v1.User.Responses;

namespace VirtualRoulette.Contracts.v1.User.Requests.Commands;

public class SignInCommand : IRequest<Response<SignInResponse>>
{
    public string Username { get; set; }
    
    public string Password { get; set; }
}