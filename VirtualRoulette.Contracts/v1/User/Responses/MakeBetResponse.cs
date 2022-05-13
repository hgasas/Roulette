namespace VirtualRoulette.Contracts.v1.User.Responses;

public abstract class MakeBetResponse
{
    public bool Success { get; protected set; }
}

public class MakeBetResponseFailure : MakeBetResponse
{
    public string Message { get; }
    public MakeBetResponseFailure(string message)
    {
        Success = false;
        Message = message;
    }
}

public class MakeBetResponseSuccess : MakeBetResponse
{
    public long SpinId { get; set; }
    
    public int WinningNumber { get; set; }
    
    public long WonAmountInDollarCents { get; set; }
    
    public MakeBetResponseSuccess()
    {
        Success = true;
    }
}