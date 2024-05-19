
using Operations.IO.Interfaces;

namespace Operations.IO;

public class ConsoleReader : IReader
{
    public string ReadLine()
    {
        string input = Console.ReadLine();
        return input;
    }
}
