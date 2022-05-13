using VirtualRoulette.Domain.Common;

namespace VirtualRoulette.Domain.Entities;

public class Jackpot : AggregateRoot
{
    public long AmountInDollarCents { get; private set; }

    public Jackpot(long id)
    {
        Id = id;
    }
    
    public void IncreaseAmount(long amountInDollarCents)
    {
        AmountInDollarCents += amountInDollarCents;
    }
}