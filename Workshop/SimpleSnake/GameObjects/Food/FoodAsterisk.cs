namespace SimpleSnake.GameObjects.Food;

public class FoodAsterisk : Food
{
    private const char CurrentSymbol = '*';
    private const int Points = 1;

    public FoodAsterisk(int x, int y)
        : base(x, y, Points, CurrentSymbol)
    {
    }
}