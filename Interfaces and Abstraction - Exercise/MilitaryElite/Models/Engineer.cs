
using MilitaryElite.Enums;
using MilitaryElite.Models.Interfaces;
using System.Collections.ObjectModel;
using System.Text;

namespace MilitaryElite.Models;

public class Engineer : SpecialisedSoldier, IEngineer
{
    public Engineer(string id, string firstName, string lastName, decimal salary, Corps corps, List<IRepair> repairs) 
        : base(id, firstName, lastName, salary, corps)
    {
        Repairs = repairs.AsReadOnly();
    }

    public IReadOnlyCollection<IRepair> Repairs {get; private set;}

    public override string ToString()
    {
        StringBuilder stringBuilder = new StringBuilder();
        stringBuilder.AppendLine(base.ToString());
        stringBuilder.AppendLine("Repairs:");

        foreach (IRepair repair in Repairs)
        {
            stringBuilder.AppendLine("  " + repair.ToString());
        }

        return stringBuilder.ToString().TrimEnd();
    }
}
