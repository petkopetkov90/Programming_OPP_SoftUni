using System.Numerics;



string[] elements = Console.ReadLine().Split(" ");

BigInteger sum = 0;

for (int i = 0; i < elements.Length; i++)
{
    try
    {
        int currentNumber = Convert.ToInt32(elements[i]);
        sum += currentNumber;
    }
    catch (FormatException)
    {
        Console.WriteLine($"The element '{elements[i]}' is in wrong format!");
    }
    catch (OverflowException)
    {
        Console.WriteLine($"The element '{elements[i]}' is out of range!");
    }
    finally
    {
        Console.WriteLine($"Element '{elements[i]}' processed - current sum: {sum}");
    }
}

Console.WriteLine($"The total sum of all integers is: {sum}");