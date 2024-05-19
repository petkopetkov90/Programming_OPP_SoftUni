using Border_Control.Models.Interfaces;

namespace Border_Control.Models;

public class Robot : IRobot
{
    public Robot(string model, string id)
    {
        Model = model;
        Id = id;
    }

    public string Model { get; private set; }

    public string Id { get; private set; }
}
