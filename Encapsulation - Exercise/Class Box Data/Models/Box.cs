namespace ClassBoxData.Models;

public class Box
{
    private const string exceptionMessage = "{0} cannot be zero or negative.";

    private double length;
    private double width;
    private double height;

    public Box(double length, double width, double height)
    {
        Length = length;
        Width = width;
        Height = height;
    }

    public double Length
    {
        get => length;
        private set
        {
            if (value <= 0)
            {
                throw new ArgumentException(string.Format(exceptionMessage, nameof(Length)));
            }

            length = value;
        }
    }
    public double Width
    {
        get => width;
        private set
        {
            if (value <= 0)
            {
                throw new ArgumentException(string.Format(exceptionMessage, nameof(Width)));
            }

            width = value;
        }
    }
    public double Height
    {
        get => height;
        private set
        {
            if (value <= 0)
            {
                throw new ArgumentException(string.Format(exceptionMessage, nameof(Height)));
            }

            height = value;
        }
    }

    public double SurfaceArea() => 2 * length * width + LateralSurfaceArea();

    public double LateralSurfaceArea() => 2 * length * height + 2 * width * height;

    public double Volume() => length * width * height;
}

