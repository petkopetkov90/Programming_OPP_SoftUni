
try
{
    Console.WriteLine(CalculateSquareRoot());
}
catch (Exception exception)
{
    Console.WriteLine(exception.Message);
}
finally
{
    Console.WriteLine("Goodbye.");
}

double CalculateSquareRoot()
{
    int number = int.Parse(Console.ReadLine());

    if (number < 0)
    {
        throw new Exception("Invalid number.");
    }

    return Math.Sqrt(number);
}
