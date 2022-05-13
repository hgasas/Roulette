using MediatR;
using VirtualRoulette.Application.RepositoryInterfaces;
using VirtualRoulette.Common;
using VirtualRoulette.Contracts.v1.User.Requests.Queries;
using VirtualRoulette.Contracts.v1.User.Responses;

namespace VirtualRoulette.Application.User.Queries;

public class GetUserGameHistoryQueryHandler : IRequestHandler<GetUserGameHistoryQuery, Response<GetUserGameHistoryResponse>>
{
    private readonly IBetRepository _betRepository;

    public GetUserGameHistoryQueryHandler(IBetRepository betRepository)
    {
        _betRepository = betRepository;
    }

    public async Task<Response<GetUserGameHistoryResponse>> Handle(GetUserGameHistoryQuery command, CancellationToken cancellationToken)
    {
        var userGames = await _betRepository.GetByQueryAsync(b => b.UserId == command.UserId);

        return ResponseHelper<GetUserGameHistoryResponse>.GetResponse(StatusCode.Success, new GetUserGameHistoryResponse
        {
            GameHistory = userGames.Select(ug => new GetUserGameHistoryResponse.GameHistoryModel()
            {
                MadeAt = ug.CreatedAt,
                SpinId = ug.SpinId,
                BetAmountInDollarCents = ug.BetAmountInDollarCents,
                WonAmountInDollarCents = ug.WonAmountInDollarCents
            })
        });
    }
}