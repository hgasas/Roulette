using MediatR;
using VirtualRoulette.Contracts.v1.User.Responses;

namespace VirtualRoulette.Contracts.v1.User.Requests.Queries;

public class GetUserGameHistoryQuery : IRequest<GetUserGameHistoryResponse>
{
    public long UserId { get; set; }
}