using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using VirtualRoulette.Application.RepositoryInterfaces;
using VirtualRoulette.Infrastructure.Persistence.Repositories;

namespace VirtualRoulette.Infrastructure.Installers;

public class RepositoryInstaller : IInstaller
{
    public void InstallServices(IServiceCollection services, IConfiguration configuration)
    {
        services.AddScoped<IUserRepository, UserRepository>();
        services.AddScoped<IBetRepository, BetRepository>();
        services.AddScoped<IJackpotRepository, JackpotRepository>();
    }
}