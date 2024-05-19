using SimpleSnake.Enums;
using SimpleSnake.GameObjects;
using SimpleSnake.GameObjects.Food;
using System;
using System.Linq;

namespace SimpleSnake.Utilities;

public static class UserInteraction
{
    private static readonly Random Random = new Random();

    public static void ProceedUserChoice()
    {
        ConsoleKeyInfo key = Console.ReadKey();

        while (key.Key != ConsoleKey.Enter && key.Key != ConsoleKey.Escape)
        {
            key = Console.ReadKey();

        }

        if (key.Key == ConsoleKey.Escape)
        {
            Console.SetCursorPosition(0, GameSettings.FieldStartPositionY + GameSettings.FieldHeight + 2);
            Environment.Exit(1);
        }

        else
        {
            GameMessages.PrintGameMessage(GameMessages.EmptyField);
        }
    }

    public static Direction GetUserDirection(Direction currentDirection)
    {
        ConsoleKeyInfo key = Console.ReadKey();

        if (key.Key == ConsoleKey.UpArrow && currentDirection != Direction.Down)
        {
            return Direction.Up;
        }

        if (key.Key == ConsoleKey.DownArrow && currentDirection != Direction.Up)
        {
            return Direction.Down;
        }

        if (key.Key == ConsoleKey.LeftArrow && currentDirection != Direction.Right)
        {
            return Direction.Left;
        }

        if (key.Key == ConsoleKey.RightArrow && currentDirection != Direction.Left)
        {
            return Direction.Right;
        }

        return currentDirection;
    }

    public static Food GetRandomFood(Food[] foods)
    {
        int index = Random.Next(0, foods.Length);
        Food currentFood = foods[index];
        currentFood.SetRandomPosition(Random.Next(GameSettings.FoodStartPositionX, GameSettings.FoodEndPositionX),
            Random.Next(GameSettings.FoodStartPositionY, GameSettings.FoodEndPositionY));

        return currentFood;
    }

    public static GameState GetCurrentGameState(Direction direction, Snake snake, SnakeObject snakeHead, Wall wall,
        Food currentFood)
    {
        Point headNextPosition = GetNextHeadPosition(direction, snakeHead);

        if (headNextPosition.X == wall.CurrentWallObject.X
            || headNextPosition.Y == wall.CurrentWallObject.Y
            || headNextPosition.X == wall.CurrentWallObject.X + GameSettings.FieldLength + 1
            || headNextPosition.Y == wall.CurrentWallObject.Y + GameSettings.FieldHeight + 1)
        {
            return GameState.Over;
        }
        else if (headNextPosition.X == currentFood.X
            && headNextPosition.Y == currentFood.Y)
        {
            return GameState.FoodEaten;
        }
        else if (snake.SnakeBody.Any(sb => sb.X == headNextPosition.X && sb.Y == headNextPosition.Y))
        {
            return GameState.Over;
        }

        return GameState.Running;
    }

    private static Point GetNextHeadPosition(Direction direction, SnakeObject snakeHead)
    {
        if (direction == Direction.Up)
        {
            return new Point(snakeHead.X, snakeHead.Y - 1);
        }
        else if (direction == Direction.Down)
        {
            return new Point(snakeHead.X, snakeHead.Y + 1);
        }
        else if (direction == Direction.Left)
        {
            return new Point(snakeHead.X - 1, snakeHead.Y);
        }
        else
        {
            return new Point(snakeHead.X + 1, snakeHead.Y);
        }
    }
}