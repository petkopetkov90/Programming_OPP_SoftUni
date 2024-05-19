using SimpleSnake.Core.Interfaces;
using SimpleSnake.Enums;
using SimpleSnake.GameObjects;
using SimpleSnake.GameObjects.Food;
using SimpleSnake.Utilities;
using System;
using System.Threading;

namespace SimpleSnake.Core;

public class Engine : IEngine
{
    private GameState gameState;
    private Direction direction;
    private readonly Wall wall;
    private readonly Snake snake;
    private readonly Food[] foods;
    private int score;
    private Food currentFood;


    public Engine(Wall wall, Snake snake, params Food[] foods)
    {
        this.wall = wall;
        this.snake = snake;
        this.foods = foods;
        score = 0;
    }

    public void Run()
    {
        int growCount = 0;
        PrepareNewGame();

        UserInteraction.ProceedUserChoice();

        gameState = GameState.Running;

        currentFood = UserInteraction.GetRandomFood(foods);
        currentFood.Draw();

        while (gameState != GameState.Over)
        {
            if (Console.KeyAvailable)
            {
                direction = UserInteraction.GetUserDirection(direction);
            }

            gameState = UserInteraction.GetCurrentGameState(direction, snake, snake.Head, wall, currentFood);

            if (gameState == GameState.FoodEaten)
            {
                score += currentFood.FoodPoints;
                growCount += currentFood.FoodPoints;
                currentFood = UserInteraction.GetRandomFood(foods);
                currentFood.Draw();
            }

            snake.Move(direction, growCount--);

            if (growCount < 0)
            {
                growCount = 0;
            }

            snake.Draw();

            Thread.Sleep(130);
        }

        GameMessages.PrintGameMessage(GameMessages.GameOver);

        GameMessages.PrintGameMessage(string.Format(GameMessages.UserScore, score));

        GameMessages.PrintGameMessage(GameMessages.NextGame);

        UserInteraction.ProceedUserChoice();

        Run();
    }

    private void PrepareNewGame()
    {
        Console.Clear();
        direction = Direction.Down;
        gameState = GameState.Idle;
        score = 0;
        wall.GenerateField(GameSettings.FieldLength, GameSettings.FieldHeight);
        snake.ResetSnake();
        snake.Draw();

        GameMessages.PrintGameMessage(GameMessages.StartGame);
    }
}