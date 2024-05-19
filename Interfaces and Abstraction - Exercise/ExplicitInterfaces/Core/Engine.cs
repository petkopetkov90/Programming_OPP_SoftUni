
using ExplicitInterfaces.Core.Interfaces;
using ExplicitInterfaces.Models;
using ExplicitInterfaces.Models.Interfaces;

namespace ExplicitInterfaces.Core;

public class Engine : IEngine
{
    public void Start()
    {
        string input;
        while((input = Console.ReadLine()) != "End")
        {
            string[] citizenDetails = input.Split(" ", StringSplitOptions.RemoveEmptyEntries);

            Citizen citizen = new Citizen(citizenDetails[0], citizenDetails[1], int.Parse(citizenDetails[2]));

            Console.WriteLine(((IPerson)citizen).GetName());
            Console.WriteLine(((IResident)citizen).GetName());
        }
       
    }
}
