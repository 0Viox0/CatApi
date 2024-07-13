namespace Bll.CustomExceptions;

public class FriendsWithItselfException : Exception
{
    public FriendsWithItselfException() { }
    
    public FriendsWithItselfException(string message) : base(message) { }
    
    public FriendsWithItselfException(string message, Exception inner)
        : base(message, inner) { }
}