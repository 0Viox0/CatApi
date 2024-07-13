namespace Bll.CustomExceptions;

public class OwnerAlreadyExistsException : Exception
{
    public OwnerAlreadyExistsException() { }
    
    public OwnerAlreadyExistsException(string message) { }

    public OwnerAlreadyExistsException(string message, Exception exception)
        : base(message, exception) { }
}