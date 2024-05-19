namespace SimpleSnake.GameObjects;

public class WallObject : GameObject
{
    private const char CurrentSymbol = '\u25A0';

    public WallObject(int x, int y)
        : base(x, y, CurrentSymbol)
    {

    }
}