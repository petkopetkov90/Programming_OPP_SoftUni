using System.Collections.ObjectModel;

namespace MilitaryElite.Models.Interfaces;

public interface IEngineer : ISpecialisedSoldier
{
    IReadOnlyCollection<IRepair> Repairs { get; }
}
