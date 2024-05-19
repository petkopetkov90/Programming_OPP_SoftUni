using P04.Recharge.Interfaces;
using System;

namespace P04.Recharge;

public class Robot : Worker, IRechargeable
{

    public Robot(string id, int workingHours, int capacity, int currentPower) : 
        base(id, workingHours)
    {
        Capacity = capacity;
        CurrentPower = currentPower;
    }

    public int Capacity { get; private set; }

    public int CurrentPower { get; private set; }

    public override void Work(int hours)
    {
        if (hours > this.CurrentPower)
        {
            hours = CurrentPower;
        }

        base.Work(hours);
        CurrentPower -= hours;
    }

    public void Recharge()
    {
        Console.WriteLine("Recharge");
    }
}