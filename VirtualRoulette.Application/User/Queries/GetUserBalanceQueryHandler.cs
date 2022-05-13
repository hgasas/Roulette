using MediatR;
using VirtualRoulette.Application.RepositoryInterfaces;
using VirtualRoulette.Contracts.v1.User.Requests.Queries;
using VirtualRoulette.Contracts.v1.User.Responses;

namespace VirtualRoulette.Application.User.Queries;

public class GetUserBalanceQueryHandler : IRequestHandler<GetUserBalanceQuery, GetUserBalanceResponse>
{
    private readonly IUserRepository _userRepository;

    public GetUserBalanceQueryHandler(IUserRepository userRepository)
    {
        _userRepository = userRepository;
    }

    public async Task<GetUserBalanceResponse> Handle(GetUserBalanceQuery command, CancellationToken cancellationToken)
    {
        var user = await _userRepository.GetByIdAsync(command.UserId);
        if(user == null)
        {
            throw new Exception(nameof(User)); //TODO not found exception
        }

        return new GetUserBalanceResponse()
        {
            BalanceInDollarCents = user.BalanceInDollarCents
        };
    }
}