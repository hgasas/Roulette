using MediatR;
using VirtualRoulette.Contracts.v1.User.Responses;

namespace VirtualRoulette.Contracts.v1.User.Requests.Commands;

public class MakeBetCommand : IRequest<MakeBetResponse>
{
    public long UserId { get; set; }
    
    public string BetString { get; set; }
}