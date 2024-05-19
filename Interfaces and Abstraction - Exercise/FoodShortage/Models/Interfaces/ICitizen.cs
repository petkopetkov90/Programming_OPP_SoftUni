
namespace FoodShortage.Models.Interfaces;

public interface ICitizen : IIdentifiable, IBirthable
{
    string Name { get; }
    int Age { get; }
}
