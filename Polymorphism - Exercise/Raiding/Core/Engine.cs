
using Raiding.Core.Interfaces;
using Raiding.Factories.Interfaces;
using Raiding.IO.Interfaces;
using Raiding.Models.Interfaces;

namespace Raiding.Core;

public class Engine : IEngine
{
    private readonly IReader reader;
    private readonly IWriter writer;
    private readonly IHeroFactory heroFactory;

    public Engine(IReader reader, IWriter writer, IHeroFactory heroFactory)
    {
        this.reader = reader;
        this.writer = writer;
        this.heroFactory = heroFactory;
    }

    public void Start()
    {
        ICollection<IHero> raidGroup = new List<IHero>();

        int numberOfHeroes = int.Parse(reader.ReadLine());

        for (int i = 0; i < numberOfHeroes; i++)
        {
            string heroName = reader.ReadLine();
            string heroType = reader.ReadLine();
            
            try
            {
                IHero hero = heroFactory.CreateHero(heroType, heroName);
                raidGroup.Add(hero);

            }
            catch (Exception exception)
            {
                i--;
                writer.WriteLine(exception.Message);
            }
        }

        int bossPower = int.Parse(reader.ReadLine());

        foreach (var hero in raidGroup)
        {
            writer.WriteLine(hero.CastAbility());
        }

        int totalHeroPowers = raidGroup.Sum(x => x.Power);

        writer.WriteLine(GetBattleResult(bossPower, totalHeroPowers));
    }

    private string GetBattleResult(int bossPower, int totalHeroPowers)
    {

        if (bossPower > totalHeroPowers)
        {
            return "Defeat...";
        }

        return "Victory!";
    }
}
