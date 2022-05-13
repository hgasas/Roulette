namespace VirtualRoulette.Contracts.v1.User.Responses;

public class MakeBetResponse
{
    public long SpinId { get; set; }
    
    public int WinningNumber { get; set; }
    
    public long WonAmountInDollarCents { get; set; }
}