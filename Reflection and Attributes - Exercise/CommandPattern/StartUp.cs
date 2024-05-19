using CommandPattern.Core;
using CommandPattern.Core.Contracts;

namespace CommandPattern;

public class StartUp
{
    public static void Main(string[] args)
    {
        ICommandInterpreter commandInterpreter = new CommandInterpreter();
        IEngine engine = new Engine(commandInterpreter);
        engine.Run();
    }
}
