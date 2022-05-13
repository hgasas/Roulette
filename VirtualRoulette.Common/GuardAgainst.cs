using System.Runtime.CompilerServices;

namespace VirtualRoulette.Common;

public static class GuardAgainst
{
    /// <summary>
    /// Throws an ArgumentNullException if the given argument is null.
    /// </summary>
    /// <param name="value"></param>
    /// <param name="parameterName"></param>
    /// <typeparam name="T"></typeparam>
    /// <returns></returns>
    /// <exception cref="ArgumentNullException"></exception>
    public static T Null<T>(T value, [CallerArgumentExpression("value")] string parameterName = "")
    {
        if (value is null)
        {
            throw new ArgumentNullException(parameterName);
        }

        return value;
    }

    /// <summary>
    /// Throws an ArgumentNullException if the given argument is null or whitespace.
    /// </summary>
    /// <param name="value"></param>
    /// <param name="parameterName"></param>
    /// <returns></returns>
    /// <exception cref="ArgumentException"></exception>
    public static string NullOrWhiteSpace(
        string value, [CallerArgumentExpression("value")] string parameterName = "")
    {
        if (string.IsNullOrWhiteSpace(value))
        {
            throw new ArgumentException($"{parameterName} cannot be null or empty", parameterName);
        }

        return value;
    }

    /// <summary>
    /// Throws an ArgumentNullException if the given argument is negative
    /// </summary>
    /// <param name="value"></param>
    /// <param name="parameterName"></param>
    /// <returns></returns>
    /// <exception cref="ArgumentException"></exception>
    public static long Negative(long value, [CallerArgumentExpression("value")] string parameterName = "")
    {
        if(value < 0)
        {
            throw new ArgumentException($"{parameterName} cannot be negative", parameterName);
        }

        return value;
    }
}