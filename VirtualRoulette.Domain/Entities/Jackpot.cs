using VirtualRoulette.Domain.Common;

namespace VirtualRoulette.Domain.Entities;

public class Jackpot : AggregateRoot
{
    public long AmountInDollarCents { get; private set; }

    private Jackpot()
    {
    }
    
    public void IncreaseAmount(long amountInDollarCents)
    {
        Id = new Random().Next();
        AmountInDollarCents += amountInDollarCents;
    }
}