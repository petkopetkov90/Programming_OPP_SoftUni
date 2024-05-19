using CollectionHierarchy.Models.Interfaces;

namespace CollectionHierarchy.Models;

public class MyList : IMyList
{
    private const int Index = 0;
    private Stack<string> collection;

    public MyList()
    {
        collection = new Stack<string>();
    }

    public int Used => collection.Count;

    public int Add(string item)
    {
        collection.Push(item);
        return Index;
    }

    public string Remove()
    {
        return collection.Pop();
    }
}
