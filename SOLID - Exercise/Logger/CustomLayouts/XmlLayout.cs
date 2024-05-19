
using LoggerLib.Layouts.Interfaces;
using System.Text;

namespace LoggerApp.CustomLayouts;

public class XmlLayout : ILayout
{
    public string Format => GetFormat();

    private string GetFormat()
    {
        StringBuilder formatBuilder = new StringBuilder();

        formatBuilder.AppendLine("<log>");
        formatBuilder.AppendLine("  <date>{0}</date>");
        formatBuilder.AppendLine("  <level>{1}</level>");
        formatBuilder.AppendLine("  <message>{2}</message>");
        formatBuilder.AppendLine("</log>");

        return formatBuilder.ToString().TrimEnd();
    }
}
