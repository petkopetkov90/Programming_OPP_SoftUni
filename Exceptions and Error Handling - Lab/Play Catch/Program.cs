
List<int> integers = Console.ReadLine()
    .Split(" ", StringSplitOptions.RemoveEmptyEntries)
    .Select(i => int.Parse(i))
    .ToList();

int exceptionsCount = 0;

while (exceptionsCount < 3)
{
    string[] command = Console.ReadLine().Split(" ");

    try
    {
        switch (command[0])
        {
            case "Replace":
                Replace(int.Parse(command[1]), int.Parse(command[2]));
                break;
            case "Print":
                Print(int.Parse(command[1]), int.Parse(command[2]));
                break;
            case "Show":
                Show(int.Parse(command[1]));
                break;
        }
    }
    catch (ArgumentOutOfRangeException)
    {
        exceptionsCount++;
        Console.WriteLine("The index does not exist!");
    }
    catch (FormatException)
    {
        exceptionsCount++;
        Console.WriteLine("The variable is not in the correct format!");
    }
}

Console.WriteLine(string.Join(", ", integers));


void Replace(int index, int element)
{
    integers[index] = element;
}
void Print(int startIndex, int endIndex)
{
    List<int> integersToPrint = new List<int>();

    for (int i = startIndex; i <= endIndex; i++)
    {
        integersToPrint.Add(integers[i]);
    }
    Console.WriteLine(string.Join(", ", integersToPrint));
}
void Show(int index)
{
    Console.WriteLine(integers[index]);
}

