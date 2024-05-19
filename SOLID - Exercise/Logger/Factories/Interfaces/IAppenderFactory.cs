
using LoggerLib.Appenders.Interfaces;
using LoggerLib.Enums;
using LoggerLib.Layouts.Interfaces;
using LoggerLib.LogFiles.Interfaces;

namespace LoggerApp.Factories.Interfaces;

public interface IAppenderFactory
{
    IAppender CreateAppender(string type, ILayout layout, ReportLevel reportLevel, ILogFile logFile = null);
}
