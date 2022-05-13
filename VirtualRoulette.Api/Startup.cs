using MediatR;
using Microsoft.AspNetCore.Diagnostics;
using VirtualRoulette.Api.Middlewares;
using VirtualRoulette.Common;
using VirtualRoulette.Contracts.v1;
using VirtualRoulette.Infrastructure.Installers;

namespace VirtualRoulette.Api;

class Startup
{
    public Startup(IConfiguration configuration)
    {
        Configuration = configuration;
    }

    public IConfiguration Configuration { get; }

    public void ConfigureServices(IServiceCollection services)
    {
        services.InstallServices(Configuration);
    }

    public void Configure(IApplicationBuilder app, IWebHostEnvironment environment)
    {
        if (environment.IsDevelopment())
        {
            app.UseSwagger();
            app.UseSwaggerUI();
        }
        
        app.UseExceptionHandler(appError =>
        {
            appError.Run(async context =>
            {
                const int statusCode = StatusCodes.Status500InternalServerError;
                var message = StatusMessages.GetMessageByStatusCode(StatusCode.InternalServerError);
                    
                var contextFeature = context.Features.Get<IExceptionHandlerFeature>();
                if (contextFeature != null)
                {
                    // logging here
                }
                    
                context.Response.StatusCode = StatusCodes.Status500InternalServerError;
                context.Response.ContentType = "text/plain";

                await context.Response.WriteAsync($"Status Code: {statusCode}; {message}");
            });
        });

        app.UseRouting();
        app.UseHttpsRedirection();

        app.UseAuthentication();
        app.UseAuthorization();

        // app.UseWhen( context => context.Request.Path.Value.Contains(ApiRoutes.User.Bet), appBuilder =>
        // {
        //     appBuilder.UseMiddleware<BetLoggingMiddleware>();
        // });
        
        app.UseMiddleware<TokenMiddleware>();

        app.UseEndpoints(endpoints =>
        {
            endpoints.MapControllers();
        });
    }
}