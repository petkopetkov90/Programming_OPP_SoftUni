using NauticalCatchChallenge.Core.Contracts;
using NauticalCatchChallenge.Models;
using NauticalCatchChallenge.Models.Contracts;
using NauticalCatchChallenge.Repositories;
using NauticalCatchChallenge.Repositories.Contracts;
using NauticalCatchChallenge.Utilities.Messages;
using System.Text;

namespace NauticalCatchChallenge.Core;

public class Controller : IController
{
    private IRepository<IDiver> divers;
    private IRepository<IFish> fishes;
    public Controller()
    {
        divers = new DiverRepository();
        fishes = new FishRepository();
    }

    public string DiveIntoCompetition(string diverType, string diverName)
    {
        IDiver diver;

        if (diverType == typeof(FreeDiver).Name)
        {
            diver = new FreeDiver(diverName);
        }
        else if (diverType == typeof(ScubaDiver).Name)
        {
            diver = new ScubaDiver(diverName);
        }
        else
        {
            return string.Format(OutputMessages.DiverTypeNotPresented, diverType);
        }

        if (divers.Models.Any(d => d.Name == diverName))
        {
            return string.Format(OutputMessages.DiverNameDuplication, diverName, divers.GetType().Name);
        }

        divers.AddModel(diver);
        return string.Format(OutputMessages.DiverRegistered, diverName, divers.GetType().Name);
    }

    public string SwimIntoCompetition(string fishType, string fishName, double points)
    {
        IFish fish;

        if (fishType == typeof(PredatoryFish).Name)
        {
            fish = new PredatoryFish(fishName, points);
        }
        else if (fishType == typeof(ReefFish).Name)
        {
            fish = new ReefFish(fishName, points);
        }
        else if (fishType == typeof(DeepSeaFish).Name)
        {
            fish = new DeepSeaFish(fishName, points);
        }
        else
        {
            return string.Format(OutputMessages.FishTypeNotPresented, fishType);
        }

        if (fishes.Models.Any(d => d.Name == fishName))
        {
            return string.Format(OutputMessages.FishNameDuplication, fishName, fishes.GetType().Name);
        }

        fishes.AddModel(fish);
        return string.Format(OutputMessages.FishCreated, fishName);
    }

    public string ChaseFish(string diverName, string fishName, bool isLucky)
    {
        IDiver currentDiver = divers.Models.FirstOrDefault(d => d.Name == diverName);
        IFish currentFish = fishes.Models.FirstOrDefault(d => d.Name == fishName);

        if (currentDiver is null)
        {
            return string.Format(OutputMessages.DiverNotFound, divers.GetType().Name, diverName);
        }

        if (currentFish is null)
        {
            return string.Format(OutputMessages.FishNotAllowed, fishName);
        }

        if (currentDiver.HasHealthIssues)
        {
            return string.Format(OutputMessages.DiverHealthCheck, diverName);
        }

        if (currentDiver.OxygenLevel < currentFish.TimeToCatch)
        {
            currentDiver.Miss(currentFish.TimeToCatch);
            return string.Format(OutputMessages.DiverMisses, diverName, fishName);

        }
        else if (currentDiver.OxygenLevel == currentFish.TimeToCatch)
        {
            if (isLucky)
            {
                currentDiver.Hit(currentFish);
                return string.Format(OutputMessages.DiverHitsFish, diverName, currentFish.Points, fishName);
            }
            else
            {
                currentDiver.Miss(currentFish.TimeToCatch);
                return string.Format(OutputMessages.DiverMisses, diverName, fishName);
            }
        }
        else
        {
            currentDiver.Hit(currentFish);
            return string.Format(OutputMessages.DiverHitsFish, diverName, currentFish.Points, fishName);
        }
    }

    public string HealthRecovery()
    {
        List<IDiver> diversWithHealthProblems = divers.Models.Where(d => d.HasHealthIssues == true).ToList();

        foreach (IDiver diver in diversWithHealthProblems)
        {
            diver.UpdateHealthStatus();
            diver.RenewOxy();
        }

        return string.Format(OutputMessages.DiversRecovered, diversWithHealthProblems.Count);
    }

    public string DiverCatchReport(string diverName)
    {
        IDiver diver = divers.GetModel(diverName);
        StringBuilder stringBuilder = new StringBuilder();
        stringBuilder.AppendLine(diver.ToString());
        stringBuilder.AppendLine("Catch Report:");

        IFish fish;
        foreach (var fishName in diver.Catch)
        {
            fish = fishes.GetModel(fishName);
            stringBuilder.AppendLine(fish.ToString());
        }

        return stringBuilder.ToString().TrimEnd();
    }

    public string CompetitionStatistics()
    {
        StringBuilder stringBuilder = new StringBuilder();
        stringBuilder.AppendLine("**Nautical-Catch-Challenge**");

        foreach (IDiver diver in divers.Models.OrderByDescending(d => d.CompetitionPoints).ThenByDescending(d => d.Catch.Count).ThenBy(d => d.Name).Where(d => d.HasHealthIssues == false))
        {
            stringBuilder.AppendLine(diver.ToString());
        }

        return stringBuilder.ToString().TrimEnd();
    }

}
