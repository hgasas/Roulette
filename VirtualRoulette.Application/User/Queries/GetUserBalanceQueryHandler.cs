using MediatR;
using VirtualRoulette.Application.RepositoryInterfaces;
using VirtualRoulette.Common;
using VirtualRoulette.Contracts.v1.User.Requests.Queries;
using VirtualRoulette.Contracts.v1.User.Responses;

namespace VirtualRoulette.Application.User.Queries;

public class GetUserBalanceQueryHandler : IRequestHandler<GetUserBalanceQuery, Response<GetUserBalanceResponse>>
{
    private readonly IUserRepository _userRepository;

    public GetUserBalanceQueryHandler(IUserRepository userRepository)
    {
        _userRepository = userRepository;
    }

    public async Task<Response<GetUserBalanceResponse>> Handle(GetUserBalanceQuery command, CancellationToken cancellationToken)
    {
        var user = await _userRepository.GetByIdAsync(command.UserId);
        if (user is null)
        {
            return ResponseHelper<GetUserBalanceResponse>.GetResponse(StatusCode.NotFound);
        }

        return ResponseHelper<GetUserBalanceResponse>.GetResponse(StatusCode.Success, new GetUserBalanceResponse
        {
            BalanceInDollarCents = user.BalanceInDollarCents
        });
    }
}