
using LoggerLib.Appenders.Interfaces;
using LoggerLib.Enums;
using LoggerLib.Loggers.Interfaces;
using System.Text;

namespace LoggerLib.Loggers;

public class Logger : ILogger
{
    private ICollection<IAppender> appenders;

    public Logger(params IAppender[] appenders)
    {
        Appenders = appenders;
    }
    public Logger(ICollection<IAppender> appenders)
    {
        Appenders = appenders;
    }

    public ICollection<IAppender> Appenders
    {
        get => appenders; 
        private set
        {
            appenders = value;
        }
    }

    public void Info(string date, string message) => LogMessage(date, message, ReportLevel.Info);

    public void Warning(string date, string message) => LogMessage(date, message, ReportLevel.Warning);

    public void Error(string date, string message) => LogMessage(date, message, ReportLevel.Error);

    public void Critical(string date, string message) => LogMessage(date, message, ReportLevel.Critical);

    public void Fatal(string date, string message) => LogMessage(date, message, ReportLevel.Fatal);

    private void LogMessage(string date, string message, ReportLevel messageReportLevel)
    {
        foreach (IAppender appender in Appenders)
        {
            if (appender.ReportLevel <= messageReportLevel)
            {
                appender.Append(date, message, messageReportLevel);
            }
        }
    }

    public override string ToString()
    {
        StringBuilder stringBuilder = new StringBuilder();
        stringBuilder.AppendLine("Logger info");

        foreach (IAppender appender in appenders)
        {
            stringBuilder.AppendLine(appender.ToString());
        }

        return stringBuilder.ToString().TrimEnd();
    }
}
