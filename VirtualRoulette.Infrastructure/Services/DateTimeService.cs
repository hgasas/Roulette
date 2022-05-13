using VirtualRoulette.Domain.ServiceInterfaces;

namespace VirtualRoulette.Infrastructure.Services;

public class DateTimeService : IDateTimeService
{
    public DateTime GetCurrentDateTime()
    {
        return DateTime.UtcNow;
    }
}