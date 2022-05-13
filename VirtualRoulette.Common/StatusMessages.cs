namespace VirtualRoulette.Common;

public static class StatusMessages
{
    public static string GetMessageByStatusCode(StatusCode statusCode) => Messages[statusCode];

    private static readonly Dictionary<StatusCode, string> Messages = new()
    {
        { StatusCode.Success, "Operation completed successfully."},
        { StatusCode.NotFound, "Resource not found."},
        { StatusCode.BadRequest, "Bad request." },
        { StatusCode.InternalServerError, "There was an error while processing request." },
        { StatusCode.InvalidPassword, "Invalid user/password combination provided." },
        { StatusCode.InvalidBet, "Bet is invalid." },
    };
}