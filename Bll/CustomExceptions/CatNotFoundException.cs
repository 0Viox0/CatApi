namespace Bll.CustomExceptions;

public class CatNotFoundException : Exception
{
    public CatNotFoundException() { }
    
    public CatNotFoundException(string message) : base(message) { }

    public CatNotFoundException(string message, Exception inner)
        : base(message, inner) { }
}
