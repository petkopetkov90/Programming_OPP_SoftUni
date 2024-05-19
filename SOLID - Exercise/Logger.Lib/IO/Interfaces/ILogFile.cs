
namespace LoggerLib.LogFiles.Interfaces;

public interface ILogFile
{
    string Name { get; }
    string Extension { get; }
    string RelativePath { get; }
    string FullPath { get; }
    int Size { get; }

    void Write(string message);

}
