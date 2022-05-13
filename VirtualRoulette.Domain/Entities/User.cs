using VirtualRoulette.Common;
using VirtualRoulette.Domain.Common;
using VirtualRoulette.Domain.ServiceInterfaces;
using VirtualRoulette.Domain.ValueObjects;

namespace VirtualRoulette.Domain.Entities;

public class User : AggregateRoot
{
    public string Username { get; private set; }
    
    public Password Password { get; private set; }
    
    public long BalanceInDollarCents { get; private set; }

    private User()
    {
    }
    
    public User(CreateUserArgs args)
    {
        ArgumentNullException.ThrowIfNull(args, nameof(args));

        Id = args.IdGenerationService.GenerateId();
        Password = GuardAgainst.Null(args.Password);
        Username = GuardAgainst.NullOrWhiteSpace(args.Username);
        BalanceInDollarCents = 0;
    }

    public void DeduceBalance(long amountInDollarCents)
    {
        amountInDollarCents = GuardAgainst.Negative(amountInDollarCents);
        
        if(BalanceInDollarCents < amountInDollarCents)
        {
            throw new Exception("Insufficient balance"); // TODO: Create custom exception
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
    public Guid Id { get; set; }
    
    public string Username { get; set; }
    
    public Password Password { get; set; }
    
    public IIdGenerationService IdGenerationService { get; set; }
}