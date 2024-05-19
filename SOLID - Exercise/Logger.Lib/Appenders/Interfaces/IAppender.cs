
using LoggerLib.Enums;
using LoggerLib.Layouts.Interfaces;

namespace LoggerLib.Appenders.Interfaces;

public interface IAppender
{
    public ILayout Layout { get; }
    public ReportLevel ReportLevel { get; }
    public int MessagesAppended { get; }

    void Append(string date, string message, ReportLevel messageReportLevel);
}
