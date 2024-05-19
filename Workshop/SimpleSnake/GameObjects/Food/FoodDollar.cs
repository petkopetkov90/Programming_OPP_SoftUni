namespace SimpleSnake.GameObjects.Food;

public class FoodDollar : Food
{
    private const char CurrentSymbol = '$';
    private const int Points = 2;

    public FoodDollar(int x, int y)
        : base(x, y, Points, CurrentSymbol)
    {
    }
}