using MilitaryElite.Core.Interfaces;
using MilitaryElite.Enums;
using MilitaryElite.Models;
using MilitaryElite.Models.Interfaces;

namespace MilitaryElite.Core;

public class Engine : IEngine
{
    public void Start()
    {
        Dictionary<string, ISoldier> soldires = new Dictionary<string, ISoldier>();

        string input;
        while ((input = Console.ReadLine()) != "End")
        {
            string[] details = input.Split(" ", StringSplitOptions.RemoveEmptyEntries);

            ISoldier soldier = null;

            if (details[0] == "Private")
            {
                soldier = new Private(details[1], details[2], details[3], decimal.Parse(details[4]));
            }
            else if (details[0] == "LieutenantGeneral")
            {
                List<IPrivate> privates = new List<IPrivate>();

                for (int i = 5; i < details.Length; i++)
                {
                    privates.Add((IPrivate)soldires[details[i]]);
                }

                soldier = new LieutenantGeneral(details[1], details[2], details[3], decimal.Parse(details[4]), privates);
            }
            else if (details[0] == "Engineer")
            {
                bool validCorps = Enum.TryParse(details[5], out Corps corps);

                List<IRepair> repairs = GetAllRepairs(details);

                if (validCorps)
                {
                    soldier = new Engineer(details[1], details[2], details[3], decimal.Parse(details[4]), corps, repairs);
                }
            }
            else if (details[0] == "Commando")
            {
                bool validCorps = Enum.TryParse(details[5], out Corps corps);

                List<IMission> missions = GetAllMissions(details);

                if (validCorps)
                {
                    soldier = new Commando(details[1], details[2], details[3], decimal.Parse(details[4]), corps, missions);
                }
            }
            else if (details[0] == "Spy")
            {
                soldier = new Spy(details[1], details[2], details[3], int.Parse(details[4]));
            }

            if (soldier != null)
            {
                soldires.Add(details[1], soldier);
            }
        }

        foreach (ISoldier solder in soldires.Values)
        {
            Console.WriteLine(solder);
        }
    }

    private List<IRepair> GetAllRepairs(string[] details)
    {
        List<IRepair> repairs = new List<IRepair>();

        for (int i = 6; i < details.Length; i += 2)
        {
            string partName = details[i];
            int hours = int.Parse(details[i + 1]);

            IRepair repair = new Repair(partName, hours);
            repairs.Add(repair);
        }

        return repairs;
    }

    private List<IMission> GetAllMissions(string[] details)
    {
        List<IMission> missions = new List<IMission>();

        for (int i = 6; i < details.Length; i += 2)
        {
            string partName = details[i];
            string state = details[i + 1];

            bool validState = Enum.TryParse(state, out MissionStates missionState);

            if (validState)
            {
                IMission mission = new Mission(partName, missionState);
                missions.Add(mission);
            }
        }

        return missions;
    }
}
