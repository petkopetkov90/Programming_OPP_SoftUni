
using CollectionHierarchy.Core.Interfaces;
using CollectionHierarchy.Models;
using System.Text;

namespace CollectionHierarchy.Core;

public class Engine : IEngine
{
    public void Start()
    {
        AddCollection addCollection = new AddCollection();
        AddRemoveCollection addRemoveCollection = new AddRemoveCollection();
        MyList myList = new MyList();

        List<int> AddedAddCollectionIndices = new List<int>();
        List<int> AddedAddRemoveCollectionIndices = new List<int>();
        List<int> AddedMyListIndices = new List<int>();

        string[] elements = Console.ReadLine().Split(" ", StringSplitOptions.RemoveEmptyEntries);
        int removeOperationsCount = int.Parse(Console.ReadLine());

        for (int i = 0; i < elements.Length; i++)
        {
            AddedAddCollectionIndices.Add(addCollection.Add(elements[i]));
            AddedAddRemoveCollectionIndices.Add(addRemoveCollection.Add(elements[i]));
            AddedMyListIndices.Add(myList.Add(elements[i]));
        }

        Console.WriteLine(string.Join(" ", AddedAddCollectionIndices));
        Console.WriteLine(string.Join(" ", AddedAddRemoveCollectionIndices));
        Console.WriteLine(string.Join(" ", AddedMyListIndices));


        StringBuilder stringBuilder = new StringBuilder();

        for (int i = 0; i < removeOperationsCount; i++)
        {
            stringBuilder.Append($"{addRemoveCollection.Remove()} ");
        }

        Console.WriteLine(stringBuilder.ToString().Trim());
        stringBuilder.Clear();

        for (int i = 0; i < removeOperationsCount; i++)
        {
            stringBuilder.Append($"{myList.Remove()} ");
        }

        Console.WriteLine(stringBuilder.ToString().Trim());
    }
}
