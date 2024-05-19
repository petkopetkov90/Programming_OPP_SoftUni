namespace TemplatePattern.Models;

public abstract class Bread
{
    protected abstract void MixIngredients();

    protected abstract void Bake();

    protected virtual void Slice()
    {
        Console.WriteLine($"Slicing the {this.GetType().Name} bread!");
    }

    public void Make()
    {
        MixIngredients();
        Bake();
        Slice();
    }
}
