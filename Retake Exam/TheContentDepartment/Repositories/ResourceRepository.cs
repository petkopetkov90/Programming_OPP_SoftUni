using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TheContentDepartment.Models.Contracts;
using TheContentDepartment.Repositories.Contracts;

namespace TheContentDepartment.Repositories;

public class ResourceRepository : IRepository<IResource>
{
    private List<IResource> models;

    public ResourceRepository()
    {
        models = new List<IResource>();
    }
    public IReadOnlyCollection<IResource> Models => models.AsReadOnly();

    public void Add(IResource model)
    {
        models.Add(model);
    }

    public IResource TakeOne(string modelName)
    {
        return models.FirstOrDefault( m => m.Name == modelName);
    }
}
