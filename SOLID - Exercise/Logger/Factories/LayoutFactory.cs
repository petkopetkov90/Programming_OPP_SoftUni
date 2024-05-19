
using LoggerApp.CustomExceptions;
using LoggerApp.CustomLayouts;
using LoggerApp.Factories.Interfaces;
using LoggerLib.Layouts;
using LoggerLib.Layouts.Interfaces;

namespace LoggerApp.Factories;

public class LayoutFactory : ILayoutFactory
{
    public ILayout CreateLayout(string type)
    {
        switch (type)
        {
            case "SimpleLayout":
                return new SimpleLayout();
            case "XmlLayout":
                return new XmlLayout();
            default:
                throw new InvalidLayOutTypeException();
        }
    }
}
