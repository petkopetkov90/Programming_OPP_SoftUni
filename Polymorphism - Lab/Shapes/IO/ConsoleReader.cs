
using Shapes.IO.Interfaces;

namespace Shapes.IO;

public class ConsoleReader : IReader
{
    public string ReadLine()
    {
        string input = Console.ReadLine();
        return input;
    }
}
