using HighwayToPeak.Models.Contracts;
using HighwayToPeak.Utilities.Messages;
using System.Text;

namespace HighwayToPeak.Models;

public abstract class Climber : IClimber
{
    private string name;
    private int stamina;
    private List<string> conqueredPeaks;

    public Climber(string name, int stamina)
    {
        Name = name;
        Stamina = stamina;
        conqueredPeaks = new List<string>();
    }

    public string Name
    {
        get => name;
        private set
        {
            if (string.IsNullOrWhiteSpace(value))
            {
                throw new ArgumentException(ExceptionMessages.ClimberNameNullOrWhiteSpace);
            }

            name = value;
        }
    }

    public int Stamina
    {
        get => stamina;
        protected set
        {
            if (value < 0)
            {
                stamina = 0;
            }
            else if (value > 10)
            {
                stamina = 10;
            }
            else
            {
                stamina = value;
            }
        }
    }

    public IReadOnlyCollection<string> ConqueredPeaks => conqueredPeaks.AsReadOnly();

    public void Climb(IPeak peak)
    {
        if (!conqueredPeaks.Contains(peak.Name))
        {
            conqueredPeaks.Add(peak.Name);
        }

        if (peak.DifficultyLevel.Equals("Extreme"))
        {
            Stamina -= 6;
        }
        else if (peak.DifficultyLevel.Equals("Hard"))
        {
            Stamina -= 4;
        }
        else if (peak.DifficultyLevel.Equals("Moderate"))
        {
            Stamina -= 2;
        }
    }

    public abstract void Rest(int daysCount);

    public override string ToString()
    {
        StringBuilder stringBuilder = new StringBuilder();
        stringBuilder.AppendLine($"{this.GetType().Name} - Name: {Name}, Stamina: {Stamina}");

        if (!conqueredPeaks.Any())
        {
            stringBuilder.AppendLine($"Peaks conquered: no peaks conquered");
        }
        else
        {
            stringBuilder.AppendLine($"Peaks conquered: {conqueredPeaks.Count}");
        }

        return stringBuilder.ToString().TrimEnd();
    }
}
