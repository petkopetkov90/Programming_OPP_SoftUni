using LoggerApp.Core.Interfaces;
using LoggerApp.CustomExceptions;
using LoggerApp.CustomLayouts;
using LoggerApp.Factories.Interfaces;
using LoggerApp.IO.Interfaces;
using LoggerLib.Appenders;
using LoggerLib.Appenders.Interfaces;
using LoggerLib.Enums;
using LoggerLib.Layouts;
using LoggerLib.Layouts.Interfaces;
using LoggerLib.LogFiles;
using LoggerLib.LogFiles.Interfaces;
using LoggerLib.Loggers;
using LoggerLib.Loggers.Interfaces;


namespace LoggerApp.Core;

public class Engine : IEngine
{
    private ILogger logger;
    private ICollection<IAppender> appenders;
    private IReader reader;
    private IWriter writer;
    private ILayoutFactory layoutFactory;
    private IAppenderFactory appenderFactory;


    public Engine(IReader reader, IWriter writer, ILayoutFactory layoutFactory, IAppenderFactory appenderFactory)
    {
        this.reader = reader;
        this.writer = writer;
        this.layoutFactory = layoutFactory;
        this.appenderFactory = appenderFactory;
        appenders = new HashSet<IAppender>();
    }


    public void Start()
    {
        int numberOfAppender = int.Parse(reader.ReadLine());

        for (int i = 0; i < numberOfAppender; i++)
        {
            try
            {
                GreateAppender();
            }
            catch (Exception exception)
            {
                writer.WriteLine(exception.Message);
            }
        }

        logger = new Logger(appenders);

        string command;
        while ((command = reader.ReadLine()) != "END")
        {
            try
            {
                LogMessage(command);
            }
            catch (Exception exception)
            {
                writer.WriteLine(exception.Message);
            }
        }

        writer.WriteLine(logger.ToString());
    }

    private void GreateAppender()
    {
        string[] currendAppender = reader.ReadLine().Split(' ', StringSplitOptions.RemoveEmptyEntries);
        string appenderType = currendAppender[0];
        string layoutType = currendAppender[1];

        ILayout layout = layoutFactory.CreateLayout(layoutType);

        ReportLevel reportLevel = ReportLevel.Info;

        if (currendAppender.Length == 3)
        {
            if (!Enum.TryParse(currendAppender[2], true, out reportLevel))
            {
                throw new InvalidReportLevelException();
            }
        }

        IAppender appender = appenderFactory.CreateAppender(appenderType, layout, reportLevel);
        appenders.Add(appender);
    }

    private void LogMessage(string command)
    {
        string[] messageDetails = command.Split("|", StringSplitOptions.RemoveEmptyEntries);
        ReportLevel reportLevel = ReportLevel.Info;
        string date = messageDetails[1];
        string message = messageDetails[2];

        if (!Enum.TryParse(messageDetails[0], true, out reportLevel))
        {
            throw new InvalidReportLevelException();
        }

        switch (reportLevel)
        {
            case ReportLevel.Info:
                logger.Info(date, message);
                break;
            case ReportLevel.Warning:
                logger.Warning(date, message);
                break;
            case ReportLevel.Error:
                logger.Error(date, message);
                break;
            case ReportLevel.Critical:
                logger.Critical(date, message);
                break;
            case ReportLevel.Fatal:
                logger.Fatal(date, message);
                break;
        }
    }
}
