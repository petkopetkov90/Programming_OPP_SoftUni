
namespace Animals.Models.Interfaces;

public interface IAnimal
{
    string Name { get; }
    string FavoriteFood { get; }
    
    string ExplainSelf();
}
