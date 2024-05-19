using MilitaryElite.Models.Interfaces;
using System.Text;

namespace MilitaryElite.Models;

public class LieutenantGeneral : Private, ILieutenantGeneral
{
    public LieutenantGeneral(string id, string firstName, string lastName, decimal salary, List<IPrivate> privates)
        : base(id, firstName, lastName, salary)
    {
        Privates = privates.AsReadOnly();
    }

    public IReadOnlyCollection<IPrivate> Privates { get; private set; }

    public override string ToString()
    {
        StringBuilder stringBuilder = new StringBuilder();
        stringBuilder.AppendLine(base.ToString());
        stringBuilder.AppendLine("Privates:");

        foreach (IPrivate privateSoldier in Privates)
        {
            stringBuilder.AppendLine("  " + privateSoldier.ToString());
        }

        return stringBuilder.ToString().TrimEnd();
    }
}
