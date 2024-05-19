using Shapes.Core;
using Shapes.Core.Interfaces;
using Shapes.IO;
using Shapes.IO.Interfaces;

namespace Shapes;

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
