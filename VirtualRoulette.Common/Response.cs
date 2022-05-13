namespace VirtualRoulette.Common;

public class Response<T>
{
    public StatusCode StatusCode { get; set; }
    
    public T Data { get; set; }
    
    public string Message { get; set; }
}