using MediatR;
using VirtualRoulette.Contracts.v1.User.Responses;

namespace VirtualRoulette.Contracts.v1.User.Requests.Queries;

public class GetUserBalanceQuery : IRequest<GetUserBalanceResponse>
{
    public long UserId { get; set; }
}