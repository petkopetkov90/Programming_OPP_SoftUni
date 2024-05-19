
using LoggerApp.Core;
using LoggerApp.Core.Interfaces;
using LoggerApp.Factories;
using LoggerApp.Factories.Interfaces;
using LoggerApp.IO;
using LoggerApp.IO.Interfaces;

namespace LoggerApp;

public class StartUp
{
    static void Main()
    {
        IReader reader = new ConsoleReader();
        IWriter writer = new ConsoleWriter();
        ILayoutFactory layoutFactory = new LayoutFactory();
        IAppenderFactory appenderFactory = new AppenderFactory();

        IEngine engine = new Engine(reader, writer, layoutFactory, appenderFactory);
        engine.Start();
    }
}
