using VirtualRoulette.Domain.Common;
using VirtualRoulette.Domain.Events;
using VirtualRoulette.Domain.Exceptions;
using VirtualRoulette.Domain.ServiceInterfaces;

namespace VirtualRoulette.Domain.Entities;

public class Bet : AggregateRoot
{
    private const int MinNumber = 1;
    
    private const int MaxNumber = 36;
    
    public long SpinId { get; private set; }
    
    public long UserId { get; set; }
    
    public virtual User User { get; private set; }
    
    public string BetString { get; private set; }

    public int WinningNumber { get; private set; }
    
    public long BetAmountInDollarCents { get; private set; }
    
    public long WonAmountInDollarCents { get; private set; }
    
    public DateTime CreatedAt { get; private set; }
    
    public bool IsWon => WonAmountInDollarCents > 0;

    private Bet()
    {
    }
    
    public Bet(CreateBetArgs args)
    {
        ArgumentNullException.ThrowIfNull(args);

        if (!IsValid(args.BetString, args.BetCheckingService))
        {
            throw new InvalidBetException("Invalid bet");
        }

        Id = args.IdGenerationService.GenerateId();
        UserId = args.User.Id;
        User = args.User;
        BetString = args.BetString;
        
        SpinId = args.IdGenerationService.GenerateId();
        BetAmountInDollarCents = args.BetCheckingService.GetBetAmountInDollarCents(BetString);
        WinningNumber = args.NumberGenerationService.GenerateNumber(MinNumber, MaxNumber);
        
        WonAmountInDollarCents = args.BetCheckingService.EstimateWinningAmountInDollarCents(BetString, WinningNumber);
        CreatedAt = args.DateTimeService.GetCurrentDateTime();
        
        AddDomainEvent(new BetMadeEvent(BetAmountInDollarCents));
    }

    public static bool IsValid(string bet, IBetCheckingService betCheckingService)
    {
        return betCheckingService.IsValid(bet);
    }
}

public class CreateBetArgs
{
    public User User { get; set; }

    public string BetString { get; set; }

    public INumberGenerationService NumberGenerationService { get; set; }
    
    public IIdGenerationService IdGenerationService { get; set; }
    
    public IBetCheckingService BetCheckingService { get; set; }
    
    public IDateTimeService DateTimeService { get; set; }
}