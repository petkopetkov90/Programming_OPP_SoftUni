using Animals.Core;
using Animals.Core.Interfaces;
using Animals.IO;
using Animals.IO.Interfaces;

namespace Animals;

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
