using SimpleSnake.GameObjects.Interfaces;
using System;

namespace SimpleSnake.GameObjects;

public class GameObject : Point, IDrawable
{
    private char symbol = ' ';

    public GameObject(int x, int y)
        : base(x, y)
    {
        Symbol = symbol;
    }

    public GameObject(int x, int y, char symbol)
        : base(x, y)
    {
        Symbol = symbol;
    }

    public char Symbol
    {
        get => symbol;
        protected set => symbol = value;
    }

    public virtual void Draw()
    {
        Console.SetCursorPosition(X, Y);
        Console.Write(Symbol);
    }
    public virtual void Draw(int x, int y)
    {
        Console.SetCursorPosition(x, y);
        Console.Write(Symbol);
    }
}