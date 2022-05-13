namespace VirtualRoulette.Contracts.v1.User.Responses;

public class GetUserGameHistoryResponse
{
    public IEnumerable<GameHistoryModel> GameHistory { get; set; }

    public class GameHistoryModel
    {
        public long SpinId { get; set; }
        
        public long BetAmountInDollarCents { get; set; }
        
        public long WonAmountInDollarCents { get; set; }
        
        public DateTime MadeAt { get; set; }
    }
}