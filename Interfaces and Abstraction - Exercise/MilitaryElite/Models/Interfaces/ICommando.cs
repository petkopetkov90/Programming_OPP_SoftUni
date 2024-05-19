
using System.Collections.ObjectModel;

namespace MilitaryElite.Models.Interfaces;

public interface ICommando : ISpecialisedSoldier
{
    IReadOnlyCollection<IMission> Missions { get; }
}
