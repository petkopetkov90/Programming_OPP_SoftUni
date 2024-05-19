
namespace P04.Recharge.Interfaces;

public interface IWorker
{
    string Id { get; }
    int WorkingHours { get; }
    void Work(int hours);
}
