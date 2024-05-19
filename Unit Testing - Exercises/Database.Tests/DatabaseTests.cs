namespace Database.Tests
{
    using NUnit.Framework;
    using System;
    using System.Linq;

    [TestFixture]
    public class DatabaseTests
    {
        private int[] array = new int[] { 1, 2, 3, 4, 5 };
        private Database database;

        [SetUp]
        public void SetUp()
        {
            database = new Database();
        }

        [TestCase(4)]
        [TestCase(16)]
        [TestCase(0)]
        public void DatabeConstructorShouldWorkCorreclty(int parametersCount)
        {
            array = new int[parametersCount];
            database = new Database(array);

            Assert.IsNotNull(database);
            Assert.IsInstanceOf<Database>(database);
            Assert.AreEqual(parametersCount, database.Count, "Constructor should set all elements which we submit to him");
            Assert.AreEqual(array, database.Fetch());
        }

        [TestCase(17)]
        public void DatabeConstructorShouldThrowAnExceptionWhenParametersAreMoreThan16(int parametersCount)
        {
            array = new int[parametersCount];

            Assert.That(() => new Database(array), Throws.Exception.TypeOf<InvalidOperationException>());
        }

        [TestCase(new int[] { 6 })]
        [TestCase(new int[] { 6, 7 })]
        [TestCase(new int[] { 1, 2, 3, 4, 5, 6, 7, 8, 9, 10, 11, 12, 13, 14, 15, 16 })]
        public void DatabaseAddMethodShouldAddCorrectly(int[] elementsToAdd)
        {
            foreach (int element in elementsToAdd)
            {
                database.Add(element);
            }

            Assert.AreEqual(elementsToAdd, database.Fetch());
            Assert.AreEqual(elementsToAdd.Length, database.Count);
        }

        [TestCase(new int[] { 1, 2, 3, 4, 5, 6, 7, 8, 9, 10, 11, 12, 13, 14, 15, 16 })]
        public void DatabaseAddMethodShouldThrowAnExceptionIfCountIsAlready16(int[] elements)
        {
            database = new Database(elements);

            Assert.That(() => database.Add(17), Throws.Exception.TypeOf<InvalidOperationException>(), "When add more elements than maximum capacity method should throw an exception");
        }

        [Test]
        public void DatabaseRemoveMethodShouldRemoveCorrectly()
        {
            database = new Database(array);
            database.Remove();
            int expectedCount = array.Length - 1;

            Assert.AreEqual(expectedCount, database.Count);
            Assert.AreEqual(array.SkipLast(1).ToArray(), database.Fetch());
            Assert.AreNotEqual(array, database.Fetch());
        }

        [Test]
        public void DatabaseRemoveMethodShouldThrowAnExceptionWhenDatabeseIsEmpty()
        {
            Assert.That(() => database.Remove(), Throws.Exception.TypeOf<InvalidOperationException>(), "Can't remove element from empty database");
        }

        [Test]
        public void DatabaseFlethMethodShouldReturnCorrectly()
        {
            database = new Database(array);

            Assert.AreEqual(array, database.Fetch());
            Assert.AreEqual(array.Length, database.Fetch().Length);
        }
    }
}
