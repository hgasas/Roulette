namespace VirtualRoulette.Domain.Exceptions;

public class InvalidBetException : DomainException
{
    public InvalidBetException(string message) : base(message)
    {
    }
}