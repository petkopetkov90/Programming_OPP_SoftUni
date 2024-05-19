namespace SimpleSnake.GameObjects;

public class Point
{
    public Point(int x, int y)
    {
        X = x;
        Y = y;
    }

    public int X { get; protected set; }
    public int Y { get; protected set; }

}