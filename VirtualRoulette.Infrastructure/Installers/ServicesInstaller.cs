using MediatR;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using VirtualRoulette.Application;
using VirtualRoulette.Application.ServiceInterfaces;
using VirtualRoulette.Domain.ServiceInterfaces;
using VirtualRoulette.Infrastructure.Services;

namespace VirtualRoulette.Infrastructure.Installers;

public class ServicesInstaller : IInstaller
{
    public void InstallServices(IServiceCollection services, IConfiguration configuration)
    {
        services.AddMediatR(typeof(ClassForGettingAssemblyFrom));

        services.AddSingleton<IHashingService, HashingService>();
        services.AddSingleton<ILogService, LogService>();
        services.AddTransient<IBetCheckingService, BetCheckingService>();
        services.AddTransient<INumberGenerationService, NumberGenerationService>();
        services.AddTransient<IIdGenerationService, IdGenerationService>();
        services.AddTransient<IDomainEventService, DomainEventService>();
        services.AddTransient<IDateTimeService, DateTimeService>();
        services.AddTransient<ILoginService, LoginService>();
    }
}