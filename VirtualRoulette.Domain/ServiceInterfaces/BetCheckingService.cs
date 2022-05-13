namespace VirtualRoulette.Domain.ServiceInterfaces;

public interface IBetCheckingService
{
    bool IsValid(string betString);
    
    long GetBetAmountInDollarCents(string betString);
    
    long EstimateWinningAmountInDollarCents(string betString, int winningNumber);
}