
using LoggerLib.Appenders.Interfaces;

namespace LoggerLib.Loggers.Interfaces;

public interface ILogger
{
    public ICollection<IAppender> Appenders { get; }
    void Info(string date, string message);
    void Warning(string date, string message);
    void Error(string date, string message);
    void Critical(string date, string message);
    void Fatal(string date, string message);
}
