namespace Prototype.Models;

public class SandwichMenu
{
    private IDictionary<string, Sandwich> sandwiches;

    public SandwichMenu()
    {
        sandwiches = new Dictionary<string, Sandwich>();
    }

    public Sandwich this[string name]
    {
        get => sandwiches[name];
        set => sandwiches.Add(name, value);
    }
}
