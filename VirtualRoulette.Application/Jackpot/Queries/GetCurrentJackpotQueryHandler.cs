using MediatR;
using VirtualRoulette.Application.RepositoryInterfaces;
using VirtualRoulette.Common;
using VirtualRoulette.Contracts.v1.Jackpot.Requests.Queries;
using VirtualRoulette.Contracts.v1.Jackpot.Responses;

namespace VirtualRoulette.Application.Jackpot.Queries;

public class GetCurrentJackpotQueryHandler : IRequestHandler<GetCurrentJackpotQuery, Response<GetCurrentJackpotResponse>>
{
    private readonly IJackpotRepository _jackpotRepository;

    public GetCurrentJackpotQueryHandler(IJackpotRepository jackpotRepository)
    {
        _jackpotRepository = jackpotRepository;
    }

    public async Task<Response<GetCurrentJackpotResponse>> Handle(
        GetCurrentJackpotQuery request, CancellationToken cancellationToken)
    {
        var jackpot = (await _jackpotRepository.GetAllAsync()).First();

        return ResponseHelper<GetCurrentJackpotResponse>.GetResponse(StatusCode.Success,new GetCurrentJackpotResponse
        {
            JackpotInDollarCents = jackpot.AmountInDollarCents
        });
    }
}