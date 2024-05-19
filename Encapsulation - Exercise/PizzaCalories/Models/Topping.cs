
namespace PizzaCalories.Models;

public class Topping
{
    private const string ErrorToppingMessage = "Cannot place {0} on top of your pizza.";
    private const string WeightErrorMessage = "{0} weight should be in the range [{1}..{2}].";
    private const double BaseCaloriesPerGram = 2;
    private const double MinWeight = 1;
    private const double MaxWeight = 50;
    private string type;
    private double weight;

    private Dictionary<string, double> toppingTypes = new Dictionary<string, double>
    {
        { "meat", 1.2},
        { "veggies", 0.8},
        { "cheese", 1.1},
        { "sauce", 0.9}
    };

    public Topping(string type, double weight)
    {
        Type = type;
        Weight = weight;
    }

    private string Type
    {
        get => type;
        set
        {
            if (!toppingTypes.ContainsKey(value.ToLower()))
            {
                throw new ArgumentException(string.Format(ErrorToppingMessage, value));
            }
            type = value;
        }
    }

    private double Weight
    {
        get => weight;
        set
        {
            if (value < MinWeight || value > MaxWeight)
            {
                throw new ArgumentException(string.Format(WeightErrorMessage, Type, MinWeight, MaxWeight));
            }
            weight = value;
        }
    }

    public double Calories => GetTotalCalories();

    private double GetTotalCalories() => Weight * BaseCaloriesPerGram * toppingTypes[Type.ToLower()];
}

