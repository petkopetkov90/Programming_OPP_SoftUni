using LoggerLib.Appenders.Interfaces;
using LoggerLib.Enums;
using LoggerLib.Layouts.Interfaces;
using LoggerLib.LogFiles.Interfaces;

namespace LoggerLib.Appenders;

public class FileAppender : IFileAppender
{
    private ILogFile logFile;
    private ReportLevel level;
    private ILayout layout;

    public FileAppender(ILayout layout, ILogFile logFile, ReportLevel reportLevel = ReportLevel.Info)
    {
        Layout = layout;
        ReportLevel = reportLevel;
        LogFile = logFile;
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
    public ILogFile LogFile
    {
        get => logFile;
        private set
        {
            logFile = value;
        }
    }

    public int MessagesAppended { get; private set; }

    public void Append(string date, string message, ReportLevel messageReportLevel)
    {
        string fullMessage = string.Format(Layout.Format, date, messageReportLevel, message);
        LogFile.Write(fullMessage);
        File.AppendAllText(LogFile.FullPath, fullMessage + Environment.NewLine);
        MessagesAppended++;
    }

    public override string ToString()
    {
        return $"Appender type: {this.GetType()}, Layout type: {Layout.GetType()}, Report level: {ReportLevel}, Messages appended: {MessagesAppended}, File size: {LogFile.Size}";
    }
}