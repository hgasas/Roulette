using MediatR;
using VirtualRoulette.Application.RepositoryInterfaces;
using VirtualRoulette.Contracts.v1.User.Requests.Queries;
using VirtualRoulette.Contracts.v1.User.Responses;

namespace VirtualRoulette.Application.User.Queries;

public class GetUserGameHistoryQueryHandler : IRequestHandler<GetUserGameHistoryQuery, GetUserGameHistoryResponse>
{
    private readonly IBetRepository _betRepository;

    public GetUserGameHistoryQueryHandler(IBetRepository betRepository)
    {
        _betRepository = betRepository;
    }

    public async Task<GetUserGameHistoryResponse> Handle(GetUserGameHistoryQuery command, CancellationToken cancellationToken)
    {
        var userGames = await _betRepository.GetByQueryAsync(b => b.UserId == command.UserId);

        return new GetUserGameHistoryResponse()
        {
            GameHistory = userGames.Select(ug => new GetUserGameHistoryResponse.GameHistoryModel()
            {
                MadeAt = ug.CreatedAt,
                SpinId = ug.SpinId,
                BetAmountInDollarCents = ug.BetAmountInDollarCents,
                WonAmountInDollarCents = ug.WonAmountInDollarCents
            })
        };
    }
}