using System;

namespace SimpleSnake.Utilities;

public static class GameSettings
{
    public static int FieldLength => 100;
    public static int FieldHeight => 30;

    public static int FieldStartPositionX => (Console.LargestWindowWidth - FieldLength) / 2;
    public static int FieldStartPositionY => (Console.LargestWindowHeight - FieldHeight) / 2;
    public static int SnakeStartPositionX => FieldStartPositionX + 2;
    public static int SnakeStartPositionY => FieldStartPositionY + 3;

    public static int FoodStartPositionX => FieldStartPositionX + 1;
    public static int FoodStartPositionY => FieldStartPositionY + 1;
    public static int FoodEndPositionX => FoodStartPositionX + 100;
    public static int FoodEndPositionY => FoodStartPositionY + 30;
}