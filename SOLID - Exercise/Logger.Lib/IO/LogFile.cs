using LoggerLib.LogFiles.Interfaces;
using System.Text;
namespace LoggerLib.LogFiles;

public class LogFile : ILogFile
{
    private readonly StringBuilder stringBuilder;
    private string name = "log";
    private string extension = "txt";
    private string relativePath = Environment.GetFolderPath(Environment.SpecialFolder.Desktop);

    public LogFile()
    {
        stringBuilder = new StringBuilder();
    }

    public LogFile(string name, string extension, string relativePath)
        : this()
    {
        Name = name;
        Extension = extension;
        RelativePath = relativePath;
    }

    public string Name
    {
        get => name;
        private set
        {
            name = value;
        }
    }

    public string Extension
    {
        get => extension;
        private set
        {
            extension = value;
        }
    }

    public string RelativePath
    {
        get => relativePath;
        private set
        {
            relativePath = value;
        }
    }

    public string FullPath
        => Path.GetFullPath($"{RelativePath}\\{Name}.{Extension}");

    public int Size => GetSize();

    public void Write(string message)
    {
        stringBuilder.Append(message);
    }

    private int GetSize()
    {
        int size = 0;

        foreach (var ch in stringBuilder.ToString())
        {
            if (char.IsLetter(ch))
            {
                size += ch;
            }
        }

        return size;
    }
}
