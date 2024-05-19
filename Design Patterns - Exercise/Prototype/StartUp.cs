using Prototype.Models;

namespace Prototype;

public class StartUp
{
    static void Main()
    {
        SandwichMenu sandwichMenu = new SandwichMenu();

        sandwichMenu["BLT"] = new Sandwich("Wheat", "Bacon", "", "Lettuce, Tomato");
        sandwichMenu["PB&J"] = new Sandwich("White", "", "", "Peanut butter, Jelly");
        sandwichMenu["Turkey"] = new Sandwich("Rye", "Turkey", "Swiss", "Lettuce, Onion, Tomato");

        Sandwich sandwich1 = sandwichMenu["BLT"].Clone();
        Sandwich sandwich2 = sandwichMenu["PB&J"].Clone();
        Sandwich sandwich3 = sandwichMenu["Turkey"].Clone();
    }
}
