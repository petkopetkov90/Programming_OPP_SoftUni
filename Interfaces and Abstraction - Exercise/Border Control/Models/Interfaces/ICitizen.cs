namespace Border_Control.Models.Interfaces;

public interface ICitizen : IIdentifiable
{
    string Name { get; }

    int Age { get; }
}
