
using WildFarm.IO.Interfaces;

namespace WildFarm.IO
{
    public class FileWriter : IWriter
    {
        public void WriteLine(object obj)
        {
            string path = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.Desktop), "example.txt");

            using StreamWriter streamWriter = new StreamWriter(path, true);
            
                streamWriter.WriteLine(obj);
            
        }
    }
}
