using System;

namespace NeedForSpeed
{
    public class StartUp
    {
        public static void Main(string[] args)
        {
            SportCar car = new(125, 100);
            car.Drive(10);
            Console.WriteLine(car.Fuel);
        }
    }
}
