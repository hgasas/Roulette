using VirtualRoulette.Application.ServiceInterfaces;
using VirtualRoulette.Infrastructure.Settings;

namespace VirtualRoulette.Infrastructure.Services;

public class LogService : ILogService
{
    private readonly LoggingSettings _loggingSettings;

    public LogService(LoggingSettings loggingSettings)
    {
        _loggingSettings = loggingSettings;
    }

    public async Task LogAsync(string message, params object[] args)
    {
        //Do whatever you want with the message
        await Task.Run(() => Console.WriteLine(message, args));
    }
}