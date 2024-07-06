namespace Bll.CustomExceptions;

public class UserAlreadyExistsException : Exception
{
    public UserAlreadyExistsException() { }
    public UserAlreadyExistsException(string message) { }

    public UserAlreadyExistsException(string message, Exception exception)
        : base(message, exception) { }
}