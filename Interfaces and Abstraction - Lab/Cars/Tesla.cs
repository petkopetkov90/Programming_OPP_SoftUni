
using System.Text;

namespace Cars;

public class Tesla : ICar, IElectricCar
{
    public Tesla(string model, string color, int battery)
    {
        Model = model;
        Color = color;
        Battery = battery;
    }

    public string Model { get; private set; }

    public string Color { get; private set; }

    public int Battery { get; private set; }

    public string Start() => "Engine start";

    public string Stop() => "Breaaak!";

    public override string ToString()
    {
        StringBuilder stringBuilder = new StringBuilder();
        stringBuilder.AppendLine($"{Color} Tesla {Model} with {Battery} Batteries");
        stringBuilder.AppendLine(Start());
        stringBuilder.AppendLine(Stop());
        return stringBuilder.ToString().TrimEnd();
    }
}
