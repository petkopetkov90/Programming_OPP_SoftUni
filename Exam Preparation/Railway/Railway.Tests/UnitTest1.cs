namespace Railway.Tests
{
    using NUnit.Framework;
    using System;

    public class Tests
    {
        private const string name = "Sofia";
        private RailwayStation railwayStation;

        [SetUp]
        public void Setup()
        {
            railwayStation = new RailwayStation(name);
        }

        [Test]
        public void ConstructorShouldWorkCorrectly()
        {
            Assert.IsNotNull(railwayStation);
            Assert.IsInstanceOf<RailwayStation>(railwayStation);
            Assert.AreEqual(name, railwayStation.Name);
            Assert.IsNotNull(railwayStation.ArrivalTrains);
            Assert.IsNotNull(railwayStation.DepartureTrains);
        }

        [TestCase(null)]
        [TestCase(" ")]
        [TestCase("     ")]
        [TestCase("")]
        public void ConstructorShouldThrowAnExeptionIfNameIsNullOrWhiteSpace(string name)
        {
            ArgumentException exception = Assert.Throws<ArgumentException>(() => railwayStation = new RailwayStation(name));

            Assert.That("Name cannot be null or empty!".Equals(exception.Message));
        }

        [Test]
        public void NewArrivalOnBoardMethodEnqueueCorrectly()
        {
            string trainInfo = "new Train";

            railwayStation.NewArrivalOnBoard(trainInfo);

            Assert.AreEqual(1, railwayStation.ArrivalTrains.Count);
        }

        [Test]
        public void TrainHasArrivedMethodDequeueCorrectlyWhenTrainIsFistInQueque()
        {
            string trainInfo = "new Train";
            railwayStation.NewArrivalOnBoard(trainInfo);

            Assert.That($"{trainInfo} is on the platform and will leave in 5 minutes.".Equals(railwayStation.TrainHasArrived(trainInfo)));
            Assert.AreEqual(0, railwayStation.ArrivalTrains.Count);
            Assert.AreEqual(1, railwayStation.DepartureTrains.Count);
        }

        [Test]
        public void TrainHasArrivedMethodWorkCorrectlyWhenTrainIsNotFirstInQueue()
        {
            string trainInfo = "new Train";
            railwayStation.NewArrivalOnBoard(trainInfo);
            trainInfo = "another Train";

            Assert.That($"There are other trains to arrive before {trainInfo}.".Equals(railwayStation.TrainHasArrived(trainInfo)));
            Assert.AreEqual(1, railwayStation.ArrivalTrains.Count);
            Assert.AreEqual(0, railwayStation.DepartureTrains.Count);

        }

        [Test]
        public void TrainHasLeftMethodWorkCorrectlyWhenTrainIsNotFirstInQueue()
        {
            string trainInfo = "new Train";
            railwayStation.NewArrivalOnBoard(trainInfo);
            railwayStation.TrainHasArrived(trainInfo);

            Assert.IsFalse(railwayStation.TrainHasLeft("wrong train info"));
            Assert.IsTrue(railwayStation.TrainHasLeft(trainInfo));
            Assert.AreEqual(0, railwayStation.DepartureTrains.Count);

        }
    }
}