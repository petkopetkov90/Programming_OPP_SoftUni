
using LoggerLib.Layouts.Interfaces;

namespace LoggerLib.Layouts;

public class SimpleLayout : ILayout
{
    public string Format => GetFormat();

    private string GetFormat()
    {
        return "{0} - {1} - {2}";
    }
}

