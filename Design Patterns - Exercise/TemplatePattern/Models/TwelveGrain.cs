namespace TemplatePattern.Models;

public class TwelveGrain : Bread
{
    protected override void MixIngredients()
    {
        Console.WriteLine("Mixing ingredients for Twelve-Grain bread");
    }

    protected override void Bake()
    {
        Console.WriteLine("Baking the Twelve-Grain bread - 30min");
    }
}
