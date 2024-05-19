
namespace LoggerApp.CustomExceptions;

public class InvalidReportLevelException : Exception
{
    private const string message = "Invalid Report Level!";

    public InvalidReportLevelException()
        : base(message)
    {
    }

    public InvalidReportLevelException(string message)
    : base(message)
    {
    }
}
