
using LoggerApp.IO.Interfaces;

namespace LoggerApp.IO
{
    public class ConsoleWriter : IWriter
    {
        public void WriteLine(object obj)
        {
            Console.WriteLine(obj.ToString());
        }
    }
}
