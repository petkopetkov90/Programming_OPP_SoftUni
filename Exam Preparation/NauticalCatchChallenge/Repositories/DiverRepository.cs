using NauticalCatchChallenge.Models.Contracts;

namespace NauticalCatchChallenge.Repositories.Contracts;

public class DiverRepository : IRepository<IDiver>
{
    private List<IDiver> models;
    public DiverRepository()
    {
        models = new List<IDiver>();
    }
    public IReadOnlyCollection<IDiver> Models => models.AsReadOnly();

    public void AddModel(IDiver model)
    {
        models.Add(model);
    }

    public IDiver GetModel(string name)
    {
        return models.FirstOrDefault(m => m.Name == name);
    }
}
