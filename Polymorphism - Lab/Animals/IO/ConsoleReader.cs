
using Animals.IO.Interfaces;

namespace Animals.IO;

public class ConsoleReader : IReader
{
    public string ReadLine()
    {
        string input = Console.ReadLine();
        return input;
    }
}
