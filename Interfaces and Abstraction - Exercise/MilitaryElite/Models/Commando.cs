using MilitaryElite.Enums;
using MilitaryElite.Models.Interfaces;
using System.Text;

namespace MilitaryElite.Models;

public class Commando : SpecialisedSoldier, ICommando
{
    public Commando(string id, string firstName, string lastName, decimal salary, Corps corps, List<IMission> missions) 
        : base(id, firstName, lastName, salary, corps)
    {
        Missions = missions;
    }

    public IReadOnlyCollection<IMission> Missions { get; private set; }

    public override string ToString()
    {
        StringBuilder stringBuilder = new StringBuilder();
        stringBuilder.AppendLine(base.ToString());
        stringBuilder.AppendLine("Missions:");

        foreach (IMission mission in Missions)
        {
            stringBuilder.AppendLine("  " + mission.ToString());
        }

        return stringBuilder.ToString().TrimEnd();
    }
}
