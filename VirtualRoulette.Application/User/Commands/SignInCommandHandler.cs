using MediatR;
using VirtualRoulette.Application.RepositoryInterfaces;
using VirtualRoulette.Application.ServiceInterfaces;
using VirtualRoulette.Common;
using VirtualRoulette.Contracts;
using VirtualRoulette.Contracts.v1.User.Requests.Commands;
using VirtualRoulette.Contracts.v1.User.Responses;
using VirtualRoulette.Domain.Exceptions;
using VirtualRoulette.Domain.ServiceInterfaces;

namespace VirtualRoulette.Application.User.Commands;

public class SignInCommandHandler : IRequestHandler<SignInCommand, Response<SignInResponse>>
{
    private readonly IUserRepository _userRepository;
    private readonly ILoginService _loginService;
    private readonly IHashingService _hashingService;

    public SignInCommandHandler(IUserRepository userRepository, ILoginService loginService, IHashingService hashingService)
    {
        _userRepository = userRepository;
        _loginService = loginService;
        _hashingService = hashingService;
    }

    public async Task<Response<SignInResponse>> Handle(SignInCommand request, CancellationToken cancellationToken)
    {
        var user = await _userRepository.GetByUsernameAsync(request.Username);
        if (user is null)
        {
            return ResponseHelper<SignInResponse>.GetResponse(StatusCode.NotFound);
        }

        if (!_hashingService.VerifyHashedPassword(request.Password, user.PasswordHash))
        {
            return ResponseHelper<SignInResponse>.GetResponse(StatusCode.InvalidPassword);
        }

        return await Task.Run(() => ResponseHelper<SignInResponse>.GetResponse(StatusCode.Success, new SignInResponse()
        {
            Token = _loginService.GetAuthorizationToken(user.Username)
        }), cancellationToken);
    }
}