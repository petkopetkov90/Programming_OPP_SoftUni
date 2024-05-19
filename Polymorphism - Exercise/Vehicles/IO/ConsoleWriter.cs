
using Vehicles.IO.Interfaces;

namespace Vehicles.IO;

public class ConsoleWriter : IWriter
{
    public void WriteLine(object obj)
    {
        Console.WriteLine(obj.ToString());
    }
}
