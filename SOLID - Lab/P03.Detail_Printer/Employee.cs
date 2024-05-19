using P03.Detail_Printer.Interfaces;

namespace P03.DetailPrinter
{
    public class Employee : IEmployee
    {

        public Employee(string name)
        {
            Name = name;
        }

        public string Name { get; private set; }

        public virtual string GetDetais()
        {
            return Name;
        }
    }
}
