using ge.singular.roulette;
using VirtualRoulette.Domain.ServiceInterfaces;

namespace VirtualRoulette.Infrastructure.Services;

public class BetCheckingService : IBetCheckingService
{
    public bool IsValid(string betString)
    {
        return CheckBets.IsValid(betString).getIsValid();
    }

    public long GetBetAmountInDollarCents(string betString)
    {
        return CheckBets.IsValid(betString).getBetAmount();
    }

    public long EstimateWinningAmountInDollarCents(string betString, int winningNumber)
    {
        return CheckBets.EstimateWin(betString, winningNumber);
    }
}