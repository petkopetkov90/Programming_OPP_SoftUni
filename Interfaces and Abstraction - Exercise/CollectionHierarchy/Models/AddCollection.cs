
using CollectionHierarchy.Models.Interfaces;

namespace CollectionHierarchy.Models;

public class AddCollection : IAddCollection
{
    private List<string> collection;
    private int index = 0;

    public AddCollection()
    {
        collection = new List<string>();
    }

    public int Add(string item)
    {
        collection.Add(item);
        return index++;
    }
}
