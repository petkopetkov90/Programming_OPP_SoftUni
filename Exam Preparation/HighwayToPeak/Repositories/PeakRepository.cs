using HighwayToPeak.Models.Contracts;
using HighwayToPeak.Repositories.Contracts;

namespace HighwayToPeak.Repositories;

public class PeakRepository : IRepository<IPeak>
{
    private List<IPeak> peaks;

    public PeakRepository()
    {
        peaks = new List<IPeak>();
    }

    public IReadOnlyCollection<IPeak> All => peaks.AsReadOnly();

    public void Add(IPeak model)
    {
        peaks.Add(model);
    }

    public IPeak Get(string name)
    {
        IPeak peak = All.FirstOrDefault(p => p.Name == name);

        return peak;
    }
}
