
namespace PizzaCalories.Models;

public class Dough
{
    private const string TypeErrorMessage = "Invalid type of dough.";
    private const string WeightErrorMessage = "Dough weight should be in the range [{0}..{1}].";
    private const double BaseCaloriesPerGram = 2;
    private const double MinWeight = 1.0;
    private const double MaxWeight = 200.0;

    private string flourType;
    private string bakingTechnique;
    private double weight;

    private Dictionary<string, double> flourTipeModifiers = new Dictionary<string, double>
    {
        { "white", 1.5 },
        { "wholegrain", 1.0 }
    };

    private Dictionary<string, double> bakingTechniqueModifiers = new Dictionary<string, double>
    {
        { "crispy", 0.9},
        { "chewy", 1.1},
        { "homemade", 1.0}
    };

    public Dough(string flourType, string bakingTechnique, double weight)
    {
        FlourType = flourType;
        BakingTechnique = bakingTechnique;
        Weight = weight;
    }

    private string FlourType
    {
        get => flourType;
        set
        {
            if (!flourTipeModifiers.ContainsKey(value.ToLower()))
            {
                throw new ArgumentException(TypeErrorMessage);
            }
            flourType = value;
        }
    }
    private string BakingTechnique
    {
        get => bakingTechnique;
        set
        {
            if (!bakingTechniqueModifiers.ContainsKey(value.ToLower()))
            {
                throw new ArgumentException(TypeErrorMessage);
            }
            bakingTechnique = value;
        }
    }

    private double Weight
    {
        get => weight;
        set
        {
            if (value < MinWeight || value > MaxWeight)
            {
                throw new ArgumentException(string.Format(WeightErrorMessage, MinWeight, MaxWeight));
            }

            weight = value;
        }

    }

    public double Calories => GetTotalCalories();

    private double GetTotalCalories() => BaseCaloriesPerGram * Weight * GetFlourModifier() * GetBakingModifier();

    private double GetBakingModifier() => bakingTechniqueModifiers[BakingTechnique.ToLower()];

    private double GetFlourModifier() => flourTipeModifiers[FlourType.ToLower()];


}
