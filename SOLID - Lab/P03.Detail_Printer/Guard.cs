using P03.DetailPrinter;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace P03.Detail_Printer
{
    public class Guard : Employee
    {
        public Guard(string name, string gun) 
            : base(name)
        {
            Gun = gun;
        }

        public string Gun { get; private set; }

        public override string GetDetais()
        {
            return base.GetDetais() + $" - {Gun}";
        }
    }
}
