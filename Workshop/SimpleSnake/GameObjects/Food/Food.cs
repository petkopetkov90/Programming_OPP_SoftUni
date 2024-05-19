namespace SimpleSnake.GameObjects.Food;

public abstract class Food : GameObject
{
    protected Food(int x, int y, int foodPoints, char symbol)
        : base(x, y, symbol)
    {
        FoodPoints = foodPoints;
    }

    public int FoodPoints { get; private set; }

    public void SetRandomPosition(int X, int Y)
    {
        this.X = X;
        this.Y = Y;
    }
}