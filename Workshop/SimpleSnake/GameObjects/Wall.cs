using SimpleSnake.Utilities;

namespace SimpleSnake.GameObjects;

public class Wall
{
    private WallObject wallObject;

    public Wall()
    {
        wallObject = new WallObject(GameSettings.FieldStartPositionX, GameSettings.FieldStartPositionY);
    }

    public WallObject CurrentWallObject => wallObject;

    public void GenerateField(int fieldLength, int fieldHeight)
    {
        SetHorizontalBorder(fieldLength, fieldHeight);
        SetVerticalBorder(fieldHeight, fieldLength);
    }
    private void SetHorizontalBorder(int length, int height)
    {
        for (int col = 0 + wallObject.X; col <= length + 1 + wallObject.X; col++)
        {
            wallObject.Draw(col, height + 1 + wallObject.Y);
        }

        for (int col = 0 + wallObject.X; col <= length + 1 + wallObject.X; col++)
        {
            wallObject.Draw(col, wallObject.Y);
        }
    }

    private void SetVerticalBorder(int height, int length)
    {
        for (int row = 0 + wallObject.Y; row <= height + 1 + wallObject.Y; row++)
        {
            wallObject.Draw(wallObject.X, row);
        }

        for (int row = 0 + wallObject.Y; row <= height + 1 + wallObject.Y; row++)
        {
            wallObject.Draw(length + 1 + wallObject.X, row);
        }
    }

}