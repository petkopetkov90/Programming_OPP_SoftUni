using P03.Detail_Printer;
using P03.Detail_Printer.Interfaces;
using System.Collections.Generic;

namespace P03.DetailPrinter
{
    class Program
    {
        static void Main()
        {
            IReadOnlyCollection<IEmployee> employees = new List<IEmployee>()
            {
                { new Employee("Petko") },
                { new Manager("Georgi", new List<string>(){ "document1", "document2"}) },
                { new Guard("Joro", "Pistol") }
            };

            DetailsPrinter detailsPrinter = new DetailsPrinter(employees);
            detailsPrinter.PrintDetails();
        }
    }
}

