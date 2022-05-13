using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using VirtualRoulette.Application.Settings;

namespace VirtualRoulette.Infrastructure.Installers;

public class ConfigurationsInstaller : IInstaller
{
    public void InstallServices(IServiceCollection services, IConfiguration configuration)
    {
        var jackpotSettings = new JackpotSettings();
        configuration.Bind(nameof(JackpotSettings), jackpotSettings);
        services.AddSingleton(jackpotSettings);
    }
}