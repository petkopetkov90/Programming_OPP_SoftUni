﻿
namespace WildFarm.Models;

public abstract class Mammal : Animal
{
    protected Mammal(string name, double weight, string livingRegion) 
        : base(name, weight)
    {
        LivingRegion = livingRegion;
    }

    public string LivingRegion { get; private set; }
}
