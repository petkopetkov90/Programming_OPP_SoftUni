
using LoggerLib.LogFiles.Interfaces;

namespace LoggerLib.Appenders.Interfaces;

public interface IFileAppender : IAppender
{
    public ILogFile LogFile { get; }
}
