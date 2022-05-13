using MediatR;
using VirtualRoulette.Application.RepositoryInterfaces;
using VirtualRoulette.Contracts.v1.User.Requests.Commands;
using VirtualRoulette.Contracts.v1.User.Responses;

namespace VirtualRoulette.Application.User.Commands;

public class SignInCommandHandler : IRequestHandler<SignInCommand, SignInResponse>
{
    private readonly IUserRepository _userRepository;

    public SignInCommandHandler(IUserRepository userRepository)
    {
        _userRepository = userRepository;
    }

    public async Task<SignInResponse> Handle(SignInCommand request, CancellationToken cancellationToken)
    {
        return new SignInResponse()
        {
            Token = "Guja"
        };
    }
}