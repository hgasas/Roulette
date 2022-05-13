using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using VirtualRoulette.Application.Settings;
using VirtualRoulette.Infrastructure.Settings;

namespace VirtualRoulette.Infrastructure.Installers;

public class ConfigurationsInstaller : IInstaller
{
    public void InstallServices(IServiceCollection services, IConfiguration configuration)
    {
        var jackpotSettings = new JackpotSettings();
        configuration.Bind(nameof(JackpotSettings), jackpotSettings);
        services.AddSingleton(jackpotSettings);
        
        var loggingSettings = new LoggingSettings();
        configuration.Bind(nameof(LoggingSettings), loggingSettings);
        services.AddSingleton(loggingSettings);
    }
}