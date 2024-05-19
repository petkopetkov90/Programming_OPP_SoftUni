using SimpleSnake.Enums;
using SimpleSnake.Utilities;
using System;
using System.Collections.Generic;

namespace SimpleSnake.GameObjects;

public class Snake
{
    private SnakeObject head;
    private Queue<SnakeObject> snakeBody;

    public Snake()
    {
        head = new SnakeObject(GameSettings.SnakeStartPositionX, GameSettings.SnakeStartPositionY);
        snakeBody = new Queue<SnakeObject>();
        GenerateSnake();
    }

    public SnakeObject Head => head;
    public IReadOnlyCollection<SnakeObject> SnakeBody => snakeBody;

    public void ResetSnake()
    {
        snakeBody = new Queue<SnakeObject>();
        head = new SnakeObject(GameSettings.SnakeStartPositionX, GameSettings.SnakeStartPositionY);
        GenerateSnake();
    }

    public void Draw()
    {
        foreach (SnakeObject snakeObject in snakeBody)
        {
            snakeObject.Draw();
        }
    }

    public void Move(Direction direction, int growCount)
    {

        if (direction == Direction.Up)
        {
            head = new SnakeObject(head.X, head.Y - 1);
        }
        else if (direction == Direction.Down)
        {
            head = new SnakeObject(head.X, head.Y + 1);
        }
        else if (direction == Direction.Left)
        {
            head = new SnakeObject(head.X - 1, head.Y);
        }
        else
        {
            head = new SnakeObject(head.X + 1, head.Y);
        }

        snakeBody.Enqueue(head);

        if (growCount < 1)
        {
            GameObject currentTail = snakeBody.Dequeue();
            Console.SetCursorPosition(currentTail.X, currentTail.Y);
            Console.Write(' ');
        }
    }

    private void GenerateSnake()
    {
        snakeBody.Enqueue(new SnakeObject(GameSettings.SnakeStartPositionX, GameSettings.SnakeStartPositionY - 2));
        snakeBody.Enqueue(new SnakeObject(GameSettings.SnakeStartPositionX, GameSettings.SnakeStartPositionY - 1));
        snakeBody.Enqueue(head);
    }
}