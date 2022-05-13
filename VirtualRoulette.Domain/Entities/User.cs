using VirtualRoulette.Common;
using VirtualRoulette.Domain.Common;
using VirtualRoulette.Domain.Exceptions;
using VirtualRoulette.Domain.ServiceInterfaces;

namespace VirtualRoulette.Domain.Entities;

public class User : AggregateRoot
{
    public string Username { get; private set; }
    
    public string PasswordHash { get; private set; }
    
    public long BalanceInDollarCents { get; private set; }

    private User()
    {
    }
    
    public User(CreateUserArgs args)
    {
        ArgumentNullException.ThrowIfNull(args, nameof(args));

        Id = args.IdGenerationService.GenerateId();
        PasswordHash = args.HashingService.HashPassword(args.PlainPassword);
        Username = GuardAgainst.NullOrWhiteSpace(args.Username);
        BalanceInDollarCents = 0;
    }

    public void DeduceBalance(long amountInDollarCents)
    {
        amountInDollarCents = GuardAgainst.Negative(amountInDollarCents);
        
        if(BalanceInDollarCents < amountInDollarCents)
        {
            throw new InsufficientBalanceException("Insufficient balance");
        }
        
        BalanceInDollarCents -= GuardAgainst.Negative(amountInDollarCents);
    }
    
    public void AddBalance(long amountInDollarCents)
    {
        BalanceInDollarCents += GuardAgainst.Negative(amountInDollarCents);
    }
}

public class CreateUserArgs
{
    public long Id { get; set; }
    
    public string Username { get; set; }
    
    public string PlainPassword { get; set; }
    
    public IIdGenerationService IdGenerationService { get; set; }

    public IHashingService HashingService { get; set; }
}