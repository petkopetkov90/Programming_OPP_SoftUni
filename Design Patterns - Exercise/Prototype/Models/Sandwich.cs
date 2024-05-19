using Prototype.Models.Interfaces;

namespace Prototype.Models;

public class Sandwich : ICloneable<Sandwich>
{
    private string meat;
    private string cheese;
    private string bread;
    private string veggies;

    public Sandwich(string meat, string cheese, string bread, string veggies)
    {
        this.meat = meat;
        this.cheese = cheese;
        this.bread = bread;
        this.veggies = veggies;
    }

    public Sandwich Clone()
    {
        Console.WriteLine($"Cloning {this.ToString().TrimEnd()}");
        return MemberwiseClone() as Sandwich;
    }

    public override string ToString()
    {
        return $"Sadwich made of: {meat}, {cheese}, {bread}, {veggies}";
    }

}
