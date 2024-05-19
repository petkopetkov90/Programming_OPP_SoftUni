
using LoggerLib.Appenders.Interfaces;
using LoggerLib.Enums;
using LoggerLib.Layouts.Interfaces;

namespace LoggerLib.Appenders;

public class ConsoleAppender : IAppender
{
    private ILayout layout;
    private ReportLevel level;

    public ConsoleAppender(ILayout layout, ReportLevel reportLevel = ReportLevel.Info)
    {
        Layout = layout;
        ReportLevel = reportLevel;
    }

    public ILayout Layout
    {
        get => layout;
        private set
        {
            layout = value;
        }
    }

    public ReportLevel ReportLevel
    {
        get => level;
        private set
        {
            level = value;
        }
    }

    public int MessagesAppended { get; private set; }

    public void Append(string date, string message, ReportLevel messageReportLevel)
    {
        Console.WriteLine(string.Format(Layout.Format, date, messageReportLevel, message));
        MessagesAppended++;
    }

    public override string ToString()
    {
        return $"Appender type: {this.GetType()}, Layout type: {Layout.GetType()}, Report level: {ReportLevel}, Messages appended: {MessagesAppended}";
    }
}
