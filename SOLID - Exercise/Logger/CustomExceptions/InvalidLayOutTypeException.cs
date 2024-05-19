
namespace LoggerApp.CustomExceptions;

public class InvalidLayOutTypeException : Exception
{
    private const string message = "Invalid Layout Type!";

    public InvalidLayOutTypeException()
        : base(message)
    {
    }

    public InvalidLayOutTypeException(string message)
    : base(message)
    {
    }
}
