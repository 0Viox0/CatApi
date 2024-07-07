namespace Bll.CustomExceptions;

public class InvalidCatColorException : Exception
{
    public InvalidCatColorException() { }
    
    public InvalidCatColorException(string message) : base(message) { }
    
    public InvalidCatColorException(string message, Exception inner)
        : base(message, inner) { }
}