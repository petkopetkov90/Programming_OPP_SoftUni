
using Shapes.IO.Interfaces;

namespace Shapes.IO;

public class ConsoleWriter : IWriter
{

    public void WriteLine(object obj)
    {
        Console.WriteLine(obj.ToString());
    }
}
