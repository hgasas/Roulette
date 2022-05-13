using MediatR;
using VirtualRoulette.Common;
using VirtualRoulette.Contracts.v1.User.Responses;

namespace VirtualRoulette.Contracts.v1.User.Requests.Commands;

public class MakeBetCommand : IRequest<Response<MakeBetResponse>>
{
    public long UserId { get; set; }
    
    public string BetString { get; set; }
}