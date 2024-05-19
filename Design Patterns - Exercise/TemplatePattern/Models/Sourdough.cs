namespace TemplatePattern.Models;

public class Sourdough : Bread
{
    protected override void MixIngredients()
    {
        Console.WriteLine("Mixing ingredients for Sourdough bread");

    }

    protected override void Bake()
    {
        Console.WriteLine("Baking the Sourdough bread - 20min");

    }
}
