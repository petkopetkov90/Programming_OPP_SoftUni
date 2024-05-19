
using PizzaCalories.Models;

namespace PizzaCalories;

public class StartUp
{
    static void Main(string[] args)
    { 
        try
        {
            string pizzaName = Console.ReadLine().Split()[1];
            string[] doughDetails = Console.ReadLine().Split();

            Dough dough = new Dough(doughDetails[1], doughDetails[2], double.Parse(doughDetails[3]));
            Pizza pizza = new Pizza(pizzaName, dough);

            string toppings;
            while ((toppings = Console.ReadLine()) != "END")
            {
                string[] toppingDetails = toppings.Split(" ", StringSplitOptions.RemoveEmptyEntries);
                Topping topping = new Topping(toppingDetails[1], double.Parse(toppingDetails[2]));
                pizza.AddTopping(topping);
            }

            Console.WriteLine(pizza);
        }
        catch (Exception exception)
        {
            Console.WriteLine(exception.Message);
        }
    }
}

