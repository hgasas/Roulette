using System.Security.Claims;
using System.Text;
using VirtualRoulette.Application.ServiceInterfaces;

namespace VirtualRoulette.Api.Middlewares;

public class BetLoggingMiddleware
{
    private readonly RequestDelegate _next;
    private readonly ILogService _logService;

    public BetLoggingMiddleware(RequestDelegate next, ILogService logService)
    {
        _next = next;
        _logService = logService;
    }
    
    public async Task Invoke(HttpContext context)
    {
        var username = context.User.Claims.First(c => c.Type == ClaimTypes.NameIdentifier).Value;
        var ip = context.Connection.RemoteIpAddress!.ToString();

        context.Request.EnableBuffering();
        var buffer = new byte[context.Request.ContentLength.GetValueOrDefault()];
        await context.Request.Body.ReadAsync(buffer, 0, buffer.Length);
        var bodyAsText = Encoding.UTF8.GetString(buffer).Replace("\n", " ").Replace("\r", " ");
        
        await _logService.LogAsync("Username : {0}, IP : {1}, Request: {2}", username, ip, bodyAsText);
        context.Request.Body.Seek(0, SeekOrigin.Begin);

        await _next(context);
    }
}