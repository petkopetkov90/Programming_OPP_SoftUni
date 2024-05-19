using System;
using System.Collections.Generic;

namespace P03.DetailPrinter
{
    public class Manager : Employee
    {
        public Manager(string name, ICollection<string> documents)
            : base(name)
        {
            this.Documents = (IReadOnlyCollection<string>)documents;
        }

        public IReadOnlyCollection<string> Documents { get; private set; }

        public override string GetDetais()
        {
            return base.GetDetais() + Environment.NewLine + $"  {string.Join(Environment.NewLine + "  ", Documents)}";
        }
    }
}
