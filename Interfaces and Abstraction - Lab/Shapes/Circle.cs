
namespace Shapes;

public class Circle : IDrawable
{
    private int radius;

    public Circle(int radius)
    {
        this.radius = radius;
    }

    public void Draw()
    {
        int wide = radius * 4 + 1;
        int height = radius * 2 + 1;

        WriteUpperPart(wide, height);

        Console.WriteLine('*' + new string(' ', wide - 2) + '*');

        WriteBottomPart(wide, height);

    }

    private void WriteUpperPart(int wide, int height)
    {
        int indent;

        Console.WriteLine(new string(' ', radius) + new string('*', height) + new string(' ', radius));

        for (int i = 1; i < radius; i++)
        {
            indent = radius - 1 - i;

            Console.WriteLine(new string(' ', indent) + new string('*', 2) + new string(' ', wide - 4 - indent * 2) + new string('*', 2) + new string(' ', indent));
        }
    }
    private void WriteBottomPart(int wide, int height)
    {
        int indent;

        for (int i = 0; i < radius - 1; i++)
        {
            indent = i;

            Console.WriteLine(new string(' ', indent) + new string('*', 2) + new string(' ', wide - 4 - indent * 2) + new string('*', 2) + new string(' ', indent));
        }

        Console.WriteLine(new string(' ', radius) + new string('*', height) + new string(' ', radius));
    }

}
