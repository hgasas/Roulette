using MediatR;
using VirtualRoulette.Common;
using VirtualRoulette.Contracts.v1.Jackpot.Responses;

namespace VirtualRoulette.Contracts.v1.Jackpot.Requests.Queries;

public class GetCurrentJackpotQuery : IRequest<Response<GetCurrentJackpotResponse>>
{
}