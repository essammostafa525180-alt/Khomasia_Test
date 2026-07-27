namespace Domain.Exceptions;

public class InvalidStateDomainException : Exception
{
    public InvalidStateDomainException() : base() { }

    public InvalidStateDomainException(string message) : base(message) { }

    public InvalidStateDomainException(string message, Exception innerException) : base(message, innerException) { }
}