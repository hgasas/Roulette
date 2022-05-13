using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using VirtualRoulette.Infrastructure.Persistence;
using VirtualRoulette.Infrastructure.Settings;

namespace VirtualRoulette.Infrastructure.Installers;

public class DbInstaller : IInstaller
{
    public void InstallServices(IServiceCollection services, IConfiguration configuration)
    {
        var databaseSettings = new DatabaseSettings();
        configuration.Bind(nameof(DatabaseSettings), databaseSettings);
        services.AddSingleton(databaseSettings);
        
        services.AddDbContext<AppDbContext>(options =>
            options.UseSqlite(databaseSettings.ConnectionString));
    }
}