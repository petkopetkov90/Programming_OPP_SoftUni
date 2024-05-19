
using LoggerApp.IO.Interfaces;

namespace LoggerApp.IO;

public class ConsoleReader : IReader
{
    public string ReadLine() => Console.ReadLine();
}
