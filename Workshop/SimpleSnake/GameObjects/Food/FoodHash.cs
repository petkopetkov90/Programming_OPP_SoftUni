namespace SimpleSnake.GameObjects.Food;

public class FoodHash : Food
{
    private const char CurrentSymbol = '#';
    private const int Points = 3;

    public FoodHash(int x, int y)
        : base(x, y, Points, CurrentSymbol)
    {
    }
}