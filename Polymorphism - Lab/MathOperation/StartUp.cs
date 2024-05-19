using Operations.Core;
using Operations.Core.Interfaces;
using Operations.IO;
using Operations.IO.Interfaces;

namespace Operations;

public class StartUp
{
    static void Main(string[] args)
    {
        IReader reader = new ConsoleReader();
        IWriter writer = new ConsoleWriter();

        IEngine engine = new Engine(reader, writer);
        engine.Start();
    }
}
