
using MilitaryElite.Enums;

namespace MilitaryElite.Models.Interfaces
{
    public interface IMission
    {
        string CodeName { get; }
        
        MissionStates State { get; }

        void CompleteMission();
    }
}
