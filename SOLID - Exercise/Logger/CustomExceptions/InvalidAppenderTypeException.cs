

namespace LoggerApp.CustomExceptions;

public class InvalidAppenderTypeException : Exception
{
    private const string message = "Invalid Appender Type!";

    public InvalidAppenderTypeException()
        : base(message)
    {
    }

    public InvalidAppenderTypeException(string message)
    : base(message)
    {
    }
}
