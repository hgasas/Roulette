using System.Security.Claims;
using VirtualRoulette.Application.ServiceInterfaces;
using VirtualRoulette.Common;

namespace VirtualRoulette.Api.Middlewares;

public class TokenMiddleware
{
    private readonly RequestDelegate _next;
    private readonly ILoginService _loginService;

    public TokenMiddleware(RequestDelegate next, ILoginService loginService)
    {
        _next = next;
        _loginService = loginService;
    }
    
    public async Task InvokeAsync(HttpContext context)
    {
        if (!context.User.Identity!.IsAuthenticated)
        {
            await _next.Invoke(context);
            return;
        }
        
        var username = context.User.Claims.First(c => c.Type == ClaimTypes.NameIdentifier).Value;
        var token = _loginService.GetAuthorizationToken(username);
        
        context.Response.Headers.Add(Constants.AuthorizationHeader, token);
        
        await _next.Invoke(context);
    }
}