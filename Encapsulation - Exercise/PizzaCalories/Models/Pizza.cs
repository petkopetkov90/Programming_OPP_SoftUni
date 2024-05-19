
namespace PizzaCalories.Models;

public class Pizza
{
    private const string NameErrorMessage = "Pizza name should be between 1 and 15 symbols.";
    private const string NumberOfToppingsErrorMessage = "Number of toppings should be in range [0..10].";

    private string name;
    private List<Topping> toppings;

    public Pizza(string name, Dough dough)
    {
        Name = name;
        Dough = dough;
        toppings = new List<Topping>();
    }

    public string Name
    {
        get => name;
        private set
        {
            if (string.IsNullOrWhiteSpace(value) || value.Length > 15)
            {
                throw new ArgumentException(NameErrorMessage);
            }
            name = value;
        }
    }

    public Dough Dough { get; private set; }

    public int NumberOfToppings => toppings.Count;

    public double TotalCalories => GetDoughCalories() + GetToppingCalories();

    public void AddTopping(Topping topping)
    {
        if (NumberOfToppings >= 10)
        {
            throw new ArgumentException(NumberOfToppingsErrorMessage);
        }

        toppings.Add(topping);
    }
    public override string ToString() => $"{Name} - {TotalCalories:f2} Calories.";

    private double GetToppingCalories() => toppings.Sum(t => t.Calories);

    private double GetDoughCalories() => Dough.Calories;

}
