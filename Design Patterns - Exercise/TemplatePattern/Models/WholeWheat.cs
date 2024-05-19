namespace TemplatePattern.Models;

internal class WholeWheat : Bread
{
    protected override void MixIngredients()
    {
        Console.WriteLine("Mixing ingredients for WholeWheat bread");
    }

    protected override void Bake()
    {
        Console.WriteLine("Baking the WholeWheat bread - 15min");
    }
}