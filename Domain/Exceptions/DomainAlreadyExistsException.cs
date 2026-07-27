namespace Domain.Exceptions;

public class DomainAlreadyExistsException : Exception
{
    public DomainAlreadyExistsException(string message) : base(message)
    {
    }

    public DomainAlreadyExistsException(string message, Exception innerException) : base(message, innerException)
    {
    }
}
