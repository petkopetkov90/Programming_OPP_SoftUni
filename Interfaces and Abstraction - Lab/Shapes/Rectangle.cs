﻿
namespace Shapes;

public class Rectangle : IDrawable
{
    private int width;
    private int height;

    public Rectangle(int width, int height)
    {
        this.width = width;
        this.height = height;
    }

    public void Draw()
    {
        Console.WriteLine(new string('*', width));

        for (int i = 1; i < height - 1; i++)
        {
            Console.WriteLine('*' + new string(' ', width - 2) + '*');
        }

        Console.WriteLine(new string('*', width));
    }
}
