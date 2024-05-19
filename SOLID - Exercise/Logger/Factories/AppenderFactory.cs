
using LoggerApp.CustomExceptions;
using LoggerApp.Factories.Interfaces;
using LoggerLib.Appenders;
using LoggerLib.Appenders.Interfaces;
using LoggerLib.Enums;
using LoggerLib.Layouts.Interfaces;
using LoggerLib.LogFiles;
using LoggerLib.LogFiles.Interfaces;

namespace LoggerApp.Factories;

public class AppenderFactory : IAppenderFactory
{

    public IAppender CreateAppender(string type, ILayout layout, ReportLevel reportLevel = 0, ILogFile logFile = null)
    {
        switch (type)
        {
            case "ConsoleAppender":
                return new ConsoleAppender(layout, reportLevel);
            case "FileAppender":
                if(logFile == null)
                {
                    logFile = new LogFile();
                }
                return new FileAppender(layout, logFile, reportLevel);
            default:
                throw new InvalidAppenderTypeException();

        }
    }
}
