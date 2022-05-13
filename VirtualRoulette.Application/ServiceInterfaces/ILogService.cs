namespace VirtualRoulette.Application.ServiceInterfaces;

public interface ILogService
{
    /// <summary>
    /// Logs message to whatever logging mechanism is configured
    /// </summary>
    /// <param name="message"></param>
    /// <param name="args"></param>
    /// <returns></returns>
    Task LogAsync(string message, params object[] args);
}