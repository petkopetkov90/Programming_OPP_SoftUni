
using Raiding.Exceptions;
using Raiding.Factories.Interfaces;
using Raiding.Models;
using Raiding.Models.Interfaces;

namespace Raiding.Factories;

public class HeroFactory : IHeroFactory
{
    public IHero CreateHero(string type, string name)
    {
        switch (type)
        {
            case "Druid":
                return new Druid(name);
            case "Paladin":
                return new Paladin(name);
            case "Rogue":
                return new Rogue(name);
            case "Warrior":
                return new Warrior(name);
            default:
                throw new InvalidHeroType();
        }
    }
}
