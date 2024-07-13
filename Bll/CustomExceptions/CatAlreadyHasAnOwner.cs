namespace Bll.CustomExceptions;

public class CatAlreadyHasAnOwner : Exception
{
    public CatAlreadyHasAnOwner() { }
    
    public CatAlreadyHasAnOwner(string message) : base(message) { }
    
    public CatAlreadyHasAnOwner(string message, Exception inner)
        : base(message, inner) { }
}