using System.Runtime.CompilerServices;

namespace VirtualRoulette.Common;

public static class GuardAgainst
{
    public static T Null<T>(T value, [CallerArgumentExpression("value")] string parameterName = "")
    {
        if (value is null)
        {
            throw new ArgumentNullException(parameterName);
        }

        return value;
    }

    public static string NullOrWhiteSpace(
        string value, [CallerArgumentExpression("value")] string parameterName = "")
    {
        if (string.IsNullOrWhiteSpace(value))
        {
            throw new ArgumentException($"{parameterName} cannot be null or empty", parameterName);
        }

        return value;
    }

    public static long Negative(long value, [CallerArgumentExpression("value")] string parameterName = "")
    {
        if(value < 0)
        {
            throw new ArgumentException($"{parameterName} cannot be negative", parameterName);
        }

        return value;
    }

    public static int OutOfRange(
        int value, int min, int max, [CallerArgumentExpression("value")] string parameterName = "")
    {
        if (value < min || value > max)
        {
            throw new ArgumentException($"{parameterName} must be between {min} and {max}");
        }

        return value;
    }
}