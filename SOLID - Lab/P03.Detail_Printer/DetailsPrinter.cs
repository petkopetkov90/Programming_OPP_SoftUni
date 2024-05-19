using P03.Detail_Printer.Interfaces;
using System;
using System.Collections.Generic;

namespace P03.DetailPrinter
{
    public class DetailsPrinter
    {
        private IReadOnlyCollection<IEmployee> employees;

        public DetailsPrinter(IReadOnlyCollection<IEmployee> employees)
        {
            this.employees = employees;
        }

        public void PrintDetails()
        {
            foreach (IEmployee employee in this.employees)
            {
                Console.WriteLine(employee.GetDetais());
            }
        }
    }
}
