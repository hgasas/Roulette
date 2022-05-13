using Microsoft.EntityFrameworkCore;
using VirtualRoulette.Api;
using VirtualRoulette.Infrastructure.Persistence;

var builder = WebApplication.CreateBuilder(args);

var startup = new Startup(builder.Configuration);
startup.ConfigureServices(builder.Services);

var app = builder.Build();
startup.Configure(app, app.Environment);

var serviceScopeFactory = app.Services.GetRequiredService<IServiceScopeFactory>();
using (var serviceScope = serviceScopeFactory.CreateScope())
{
    var dbContext = serviceScope.ServiceProvider.GetService<AppDbContext>();
    dbContext.Database.Migrate();
}

app.Run();