List<int> validNumbers = new List<int>();

int start = 1;
int end = 100;

while (validNumbers.Count < 10)
{
    try
    {
        validNumbers.Add(ReadNumber(start, end));
        start = validNumbers.Last();
    }
    catch (Exception exception)
    {
        Console.WriteLine(exception.Message);
    }
}

Console.WriteLine(string.Join(", ", validNumbers));




int ReadNumber(int start, int end)
{

    if (!int.TryParse(Console.ReadLine(), out int number))
    {
        throw new Exception("Invalid Number!");
    }

    if (number <= start || number >= end)
    {
        throw new Exception($"Your number is not in range {start} - {end}!");
    }

    return number;
}