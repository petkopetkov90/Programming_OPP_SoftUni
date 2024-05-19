namespace P04.Recharge;

using System;
using P04.Recharge.Interfaces;

public class Employee : Worker, ISleeper
{
    public Employee(string id, int workingHours, decimal salary)
        : base(id, workingHours)
    {
        Salary = salary;
    }

    public decimal Salary { get; private set; }
    public void Sleep()
    {
        Console.WriteLine("Sleep");
    }
}
