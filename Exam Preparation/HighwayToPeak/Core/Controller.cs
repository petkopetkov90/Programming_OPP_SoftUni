using HighwayToPeak.Core.Contracts;
using HighwayToPeak.Models;
using HighwayToPeak.Models.Contracts;
using HighwayToPeak.Repositories;
using HighwayToPeak.Repositories.Contracts;
using HighwayToPeak.Utilities.Messages;
using System.Text;

namespace HighwayToPeak.Core;

public class Controller : IController
{
    private IList<string> difficultyLevels;
    private IRepository<IPeak> peaks;
    private IRepository<IClimber> climbers;
    private IBaseCamp baseCamp;


    public Controller()
    {
        difficultyLevels = new List<string>() { "Extreme", "Hard", "Moderate" };
        peaks = new PeakRepository();
        climbers = new ClimberRepository();
        baseCamp = new BaseCamp();
    }

    public string AddPeak(string name, int elevation, string difficultyLevel)
    {
        if (peaks.All.Any(p => p.Name == name))
        {
            return string.Format(OutputMessages.PeakAlreadyAdded, name);
        }
        if (!difficultyLevels.Contains(difficultyLevel))
        {
            return string.Format(OutputMessages.PeakDiffucultyLevelInvalid, difficultyLevel);
        }

        IPeak currentPeak = new Peak(name, elevation, difficultyLevel);
        peaks.Add(currentPeak);

        return string.Format(OutputMessages.PeakIsAllowed, name, peaks.GetType().Name);
    }

    public string NewClimberAtCamp(string name, bool isOxygenUsed)
    {
        if (climbers.All.Any(climber => climber.Name == name))
        {
            return string.Format(OutputMessages.ClimberCannotBeDuplicated, name, climbers.GetType().Name);
        }

        IClimber currentClimber;

        if (isOxygenUsed)
        {
            currentClimber = new OxygenClimber(name);
        }
        else
        {
            currentClimber = new NaturalClimber(name);
        }

        climbers.Add(currentClimber);
        baseCamp.ArriveAtCamp(currentClimber.Name);

        return string.Format(OutputMessages.ClimberArrivedAtBaseCamp, currentClimber.Name);
    }

    public string AttackPeak(string climberName, string peakName)
    {
        IClimber climber = climbers.All.FirstOrDefault(cl => cl.Name == climberName);
        IPeak peak = peaks.All.FirstOrDefault(p => p.Name == peakName);

        if (climber is null)
        {
            return string.Format(OutputMessages.ClimberNotArrivedYet, climberName);
        }

        if (peak is null)
        {
            return string.Format(OutputMessages.PeakIsNotAllowed, peakName);
        }

        if (!baseCamp.Residents.Contains(climberName))
        {
            return string.Format(OutputMessages.ClimberNotFoundForInstructions, climberName, peakName);
        }

        if (peak.DifficultyLevel.Equals("Extreme"))
        {
            if (climber.GetType().Name.Equals("NaturalClimber"))
            {

                return string.Format(OutputMessages.NotCorrespondingDifficultyLevel, climberName, peakName);
            }
        }

        baseCamp.LeaveCamp(climber.Name);
        climber.Climb(peak);

        if (climber.Stamina == 0)
        {
            return string.Format(OutputMessages.NotSuccessfullAttack, climberName);
        }
        else
        {
            baseCamp.ArriveAtCamp(climber.Name);
            return string.Format(OutputMessages.SuccessfulAttack, climberName, peakName);
        }

    }

    public string CampRecovery(string climberName, int daysToRecover)
    {

        if (!baseCamp.Residents.Contains(climberName))
        {
            return string.Format(OutputMessages.ClimberIsNotAtBaseCamp, climberName);
        }

        IClimber climber = climbers.All.First(cl => cl.Name == climberName);

        if (climber.Stamina == 10)
        {
            return string.Format(OutputMessages.NoNeedOfRecovery, climberName);
        }
        else
        {

            climber.Rest(daysToRecover);

            return string.Format(OutputMessages.ClimberRecovered, climberName, daysToRecover);
        }
    }

    public string BaseCampReport()
    {
        if (baseCamp.Residents.Count == 0)
        {
            return "BaseCamp is currently empty.";
        }

        StringBuilder stringBuilder = new StringBuilder();
        stringBuilder.AppendLine("BaseCamp residents:");

        IClimber currentClimber;

        foreach (var climber in baseCamp.Residents)
        {
            currentClimber = climbers.All.First(cl => cl.Name.Equals(climber));

            stringBuilder.AppendLine($"Name: {currentClimber.Name}, Stamina: {currentClimber.Stamina}, Count of Conquered Peaks: {currentClimber.ConqueredPeaks.Count}");

        }

        return stringBuilder.ToString().TrimEnd();
    }

    public string OverallStatistics()
    {
        StringBuilder stringBuilder = new StringBuilder();
        stringBuilder.AppendLine("***Highway-To-Peak***");

        foreach (IClimber climber in climbers.All.OrderByDescending(cl => cl.ConqueredPeaks.Count).ThenBy(cl => cl.Name))
        {
            stringBuilder.AppendLine(climber.ToString());

            List<IPeak> currentPeaks = peaks.All.Where(p => climber.ConqueredPeaks.Contains(p.Name)).ToList();

            foreach (IPeak peak in currentPeaks.OrderByDescending(p => p.Elevation).ToList())
            {
                stringBuilder.AppendLine(peak.ToString());
            }
        }

        return stringBuilder.ToString().TrimEnd();
    }
}
