namespace VirtualRoulette.Common;

public static class ResponseHelper<T> where T : class
{
    public static Response<T> GetResponse(StatusCode statusCode, T data = null)
    {
        return new Response<T>
        {
            StatusCode = statusCode,
            Message = StatusMessages.GetMessageByStatusCode(statusCode),
            Data = data
        };
    }
    
    public static Response<T> GetResponse(StatusCode statusCode, string message)
    {
        return new Response<T>
        {
            StatusCode = statusCode,
            Message = message,
            Data = null
        };
    }
}