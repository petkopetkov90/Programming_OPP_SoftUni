using System;

namespace SimpleSnake.Utilities;

public static class GameMessages
{
    public const string StartGame = "PRES ENTER TO START";
    public const string GameOver = "GAME OVER!";
    public const string UserScore = "Your score: {0}";
    public const string NextGame = "PRESS ENTER TO RESTART OR ESC TO LEAVE";
    public const string EmptyField = "                                    ";

    public static void PrintGameMessage(string message)
    {
        SetCursorPosition(message);
        Console.Write(message);
    }

    private static void SetCursorPosition(string message)
    {
        int centerMessagePossX = Console.LargestWindowWidth / 2 - message.Length / 2;
        int centerMessagePossY = Console.LargestWindowHeight / 2;

        if (message == GameMessages.NextGame)
        {
            Console.SetCursorPosition(centerMessagePossX, centerMessagePossY + 1);
        }
        else if (message == GameMessages.GameOver)
        {
            Console.SetCursorPosition(centerMessagePossX, centerMessagePossY - 1);
        }
        else
        {
            Console.SetCursorPosition(centerMessagePossX, centerMessagePossY);
        }
    }
}