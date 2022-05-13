﻿using System.Reflection;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace VirtualRoulette.Infrastructure.Installers;

public static class InstallerExtensions
{
    public static void InstallServices(this IServiceCollection services, IConfiguration configuration)
    {
        var installers = Assembly
            .GetExecutingAssembly()
            .ExportedTypes
            .Where(x => typeof(IInstaller).IsAssignableFrom(x) && !x.IsInterface && !x.IsAbstract)
            .Select(Activator.CreateInstance)
            .Cast<IInstaller>()
            .ToList();

        installers.ForEach(installer => installer.InstallServices(services, configuration));
    } 
}