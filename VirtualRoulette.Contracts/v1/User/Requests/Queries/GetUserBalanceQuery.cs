using MediatR;
using VirtualRoulette.Common;
using VirtualRoulette.Contracts.v1.User.Responses;

namespace VirtualRoulette.Contracts.v1.User.Requests.Queries;

public class GetUserBalanceQuery : IRequest<Response<GetUserBalanceResponse>>
{
    public long UserId { get; set; }
}