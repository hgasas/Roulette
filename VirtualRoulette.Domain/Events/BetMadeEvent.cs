using VirtualRoulette.Domain.Common;

namespace VirtualRoulette.Domain.Events;

public class BetMadeEvent : DomainEvent
{
    public double UserBetAmount { get; }
    
    public BetMadeEvent(double userBetAmount)
    {
        UserBetAmount = userBetAmount;
    }
}