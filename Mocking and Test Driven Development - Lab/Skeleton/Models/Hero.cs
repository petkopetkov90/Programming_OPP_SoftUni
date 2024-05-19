using System.Net.Http.Headers;
using Skeleton.Models.Interfaces;

namespace Skeleton.Models;

public class Hero : IHero
{
    private IWeapon weapon;
    private int experience;
    private string name;

    public Hero(string name, IWeapon weapon)
    {
        Name = name;
        Weapon = weapon;
    }

    public string Name { get => name; private set { name = value; } }

    public IWeapon Weapon { get => weapon; private set { weapon = value; } }

    public int Experience { get => experience; private set { experience = value; } }

    public void Attack(ITarget target)
    {
        weapon.Attack(target);

        if (target.IsDead())
        {
            Experience += target.GiveExperience();
        }
    }
}
