using CollectionHierarchy.Models.Interfaces;

namespace CollectionHierarchy.Models;

public class AddRemoveCollection : IAddRemoveCollection
{
    private const int Index = 0;
    private Queue<string> collection;

    public AddRemoveCollection()
    {
        collection = new Queue<string>();
    }

    public int Add(string item)
    {
        collection.Enqueue(item);
        return Index;
    }

    public string Remove()
    {
        return collection.Dequeue();
    }
}
