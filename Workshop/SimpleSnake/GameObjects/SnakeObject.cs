namespace SimpleSnake.GameObjects;

public class SnakeObject : GameObject
{
    private const char SnakeSymbol = '\u25CF';

    public SnakeObject(int x, int y)
        : base(x, y, SnakeSymbol)
    {
    }
}