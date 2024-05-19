
using Animals.IO.Interfaces;

namespace Animals.IO;

public class ConsoleWriter : IWriter
{
    public void WriteLine(object obj)
    {
        Console.WriteLine(obj.ToString());
    }
}
