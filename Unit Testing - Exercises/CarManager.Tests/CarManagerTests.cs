namespace CarManager.Tests
{
    using NUnit.Framework;
    using System;

    [TestFixture]
    public class CarManagerTests
    {
        private Car car;
        private string make = "Audi";
        private string model = "A6";
        private double fuelConsumption = 10;
        private double fuelCapacity = 100;

        [SetUp]
        public void SetUp()
        {
            car = new Car(make, model, fuelConsumption, fuelCapacity);
        }

        [Test]
        public void CarConstructorShouldWorkCorrectly()
        {
            double fuelAmount = 0;
            Assert.IsNotNull(car);
            Assert.IsInstanceOf<Car>(car);
            Assert.AreEqual(make, car.Make);
            Assert.AreEqual(model, car.Model);
            Assert.AreEqual(fuelConsumption, car.FuelConsumption);
            Assert.AreEqual(fuelAmount, car.FuelAmount);
            Assert.AreEqual(fuelCapacity, car.FuelCapacity);
        }

        [TestCase(null)]
        [TestCase("")]
        public void CarConstructorShouldThrowAnExceptionWhenMakeIsNullOrEmpty(string make)
        {

            ArgumentException exception = Assert.Throws<ArgumentException>(() => car = new Car(make, model, fuelConsumption, fuelCapacity));

            Assert.AreEqual("Make cannot be null or empty!", exception.Message);
        }

        [TestCase(null)]
        [TestCase("")]
        public void CarConstructorShouldThrowAnExceptionWhenModelIsNullOrEmpty(string model)
        {

            ArgumentException exception = Assert.Throws<ArgumentException>(() => car = new Car(make, model, fuelConsumption, fuelCapacity));

            Assert.AreEqual("Model cannot be null or empty!", exception.Message);
        }

        [TestCase(0)]
        [TestCase(-5)]
        public void CarConstructorShouldThrowAnExceptionFuelConsumptionIsNotPositive(double fuelConsumption)
        {

            ArgumentException exception = Assert.Throws<ArgumentException>(() => car = new Car(make, model, fuelConsumption, fuelCapacity));

            Assert.AreEqual("Fuel consumption cannot be zero or negative!", exception.Message);
        }

        [TestCase(0)]
        [TestCase(-5)]
        public void CarConstructorShouldThrowAnExceptionFuelCapacityIsNotPositive(double fuelCapacity)
        {

            ArgumentException exception = Assert.Throws<ArgumentException>(() => car = new Car(make, model, fuelConsumption, fuelCapacity));

            Assert.AreEqual("Fuel capacity cannot be zero or negative!", exception.Message);
        }

        [Test]
        public void CarPropertyMakeShouldWorkCorreclty()
        {
            Assert.AreEqual(make, car.Make);
        }

        [Test]
        public void CarPropertyModelShouldWorkCorreclty()
        {
            Assert.AreEqual(model, car.Model);
        }

        [Test]
        public void CarPropertyFuelConsumptionShouldWorkCorreclty()
        {
            Assert.AreEqual(fuelConsumption, car.FuelConsumption);
        }

        [Test]
        public void CarPropertyFuelAmountShouldWorkCorreclty()
        {
            double fuelAmount = 0;
            Assert.AreEqual(fuelAmount, car.FuelAmount);
        }

        [Test]
        public void CarPropertyFuelCapacityShouldWorkCorreclty()
        {
            Assert.AreEqual(fuelCapacity, car.FuelCapacity);
        }

        [TestCase(50)]
        public void CarRefuelMethodShouldWorkCorrectly(double fuelAmount)
        {
            double expectedAmount = 50;
            car.Refuel(fuelAmount);

            Assert.AreEqual(expectedAmount, car.FuelAmount);
        }

        [TestCase(101)]
        [TestCase(500)]
        public void CarRefuelMethodShouldFillTillMaximumCapacityWhenRefuelAmountIsBigger(double fuelAmount)
        {
            double expectedAmount = fuelCapacity;
            car.Refuel(fuelAmount);

            Assert.AreEqual(expectedAmount, car.FuelAmount);
        }

        [TestCase(0)]
        [TestCase(-15)]
        public void CarRefuelMethodShouldThorwAnExceptionWhenFuelIsNotPositive(double fuelAmount)
        {
            ArgumentException exception = Assert.Throws<ArgumentException>(() => car.Refuel(fuelAmount));

            Assert.AreEqual("Fuel amount cannot be zero or negative!", exception.Message);
        }


        [TestCase(50)]
        public void CarDriveMethodShouldWorkCorrectly(double distance)
        {
            car.Refuel(100);
            double expectedFuel = car.FuelAmount - ((distance / 100) * car.FuelConsumption);
            car.Drive(distance);

            Assert.AreEqual(expectedFuel, car.FuelAmount);
        }

        [TestCase(50)]
        public void CarDriveMethodShouldThrowAnExceptionWhenNotHaveEnoughFuelToPassGivenDistance(double distance)
        {

            InvalidOperationException exception = Assert.Throws<InvalidOperationException>(() => car.Drive(distance));

            Assert.AreEqual("You don't have enough fuel to drive!", exception.Message);
        }
    }
}