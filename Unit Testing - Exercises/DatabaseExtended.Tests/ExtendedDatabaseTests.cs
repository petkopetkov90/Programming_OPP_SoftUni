namespace DatabaseExtended.Tests
{
    using ExtendedDatabase;
    using NUnit.Framework;
    using System;
    using System.Linq;

    [TestFixture]
    public class ExtendedDatabaseTests
    {
        private Person person;
        private Database database;
        private Person[] moreThan16Persons;

        [SetUp]
        public void SetUp()
        {
            person = new Person(1, "Person1");
            database = new Database(person);
            moreThan16Persons = new Person[] { person, new Person(2, "Person2"),
            new Person(3, "Person3"),
            new Person(4, "Person4"),
            new Person(5, "Person5"),
            new Person(6, "Person6"),
            new Person(7, "Person7"),
            new Person(8, "Person8"),
            new Person(9, "Person9"),
            new Person(10, "Person10"),
            new Person(11, "Person11"),
            new Person(12, "Person12"),
            new Person(13, "Person13"),
            new Person(14, "Person14"),
            new Person(15, "Person15"),
            new Person(16, "Person16"),
            new Person(17, "Person17"),
            };
        }

        [Test]
        public void PersonConstructorShouldWorkCorrectlyAndSetIdAndUsername()
        {
            long expectedID = 1;
            string expectedUsername = "Person1";

            Assert.IsNotNull(person);
            Assert.IsInstanceOf<Person>(person);
            Assert.AreEqual(expectedID, person.Id);
            Assert.AreEqual(expectedUsername, person.UserName);
        }

        [Test]
        public void DatabaseConstructoShouldWorkCorrectlyAndSetElements()
        {
            int expectedCount = 1;

            Assert.IsInstanceOf<Database>(database);
            Assert.IsNotNull(database);
            Assert.AreEqual(expectedCount, database.Count);
        }

        [Test]
        public void DatabaseConstructoShouldThrowAnExceptionWhenGetMoreThan16Elements()
        {
            ArgumentException exception = Assert.Throws<ArgumentException>(() => database = new Database(moreThan16Persons));

            Assert.AreEqual("Provided data length should be in range [0..16]!", exception.Message, "Constructor should not be able set more than 16 elements!");
        }

        [Test]
        public void DatabaseCountShouldWorkCorrectly()
        {
            int expectedCount = 1;

            Assert.AreEqual(expectedCount, database.Count);
        }

        [Test]
        public void DatabaseAddMethodShouldAddCorrectlyAndIncreaseCount()
        {
            Person personsToAdd = new Person(2, "Person2");
            database.Add(personsToAdd);
            int expectedCount = 2;

            Assert.AreEqual(expectedCount, database.Count);
            Assert.AreEqual(personsToAdd.UserName, database.FindById(personsToAdd.Id).UserName);
        }

        [Test]
        public void DatabaseAddMethodShouldThrowAnExceptionIfWhenCountIsAlready16()
        {
            database = new Database(moreThan16Persons.SkipLast(1).ToArray());

            InvalidOperationException exception = Assert.Throws<InvalidOperationException>(() => database.Add(new Person(17, "Person17")));

            Assert.AreEqual("Array's capacity must be exactly 16 integers!", exception.Message, "Add methon should throw an exeption when try to add if in database already have 16 elements!");
        }

        [Test]
        public void DatabaseAddMethodShouldThrowAnExceptionWhenAddWithSameID()
        {
            InvalidOperationException exception = Assert.Throws<InvalidOperationException>(() => database.Add(new Person(1, "Person2")));

            Assert.AreEqual("There is already user with this Id!", exception.Message, "Add method should throw an exeption when try to add person with same Id like any from database!");
        }

        [Test]
        public void DatabaseAddMethodShouldThrowAnExceptionWhenAddWithSameUsername()
        {
            Exception exception = Assert.Throws<InvalidOperationException>(() => database.Add(new Person(2, "Person1")));

            Assert.AreEqual("There is already user with this username!", exception.Message, "Add method should throw an exeption when try to add person with same username like any from database!");
        }

        [Test]
        public void DatabaseRemoveMethodShouldRemoveCorrectly()
        {
            int expectedCount = 0;
            database.Remove();

            Assert.AreEqual(expectedCount, database.Count);
        }

        [Test]
        public void DatabaseRemoveMethodShouldThrowAnExceptionWhenDatabaseIsEmpty()
        {
            database.Remove();

            Assert.Throws<InvalidOperationException>(() => database.Remove());
        }

        [Test]
        public void DatabaseFindByUsernameMethodShouldFindCorrectPerson()
        {
            Assert.AreEqual(person, database.FindByUsername(person.UserName));
        }

        [TestCase(null)]
        [TestCase("")]
        public void DatabaseFindByUsernameMethodShouldThrowAnExceptionWhenUsernameIsNullOrEmpty(string username)
        {
            ArgumentNullException exception = Assert.Throws<ArgumentNullException>(() => database.FindByUsername(username));

            Assert.AreEqual("Username parameter is null!", exception.ParamName, "FindByUsername method should throw an exception if username is null or empty!");
        }

        [TestCase("Pesho")]
        [TestCase("person1")]
        public void DatabaseFindByUsernameMethodShouldThrowAnExceptionWhenUsernameDoesNotExist(string username)
        {
            InvalidOperationException exception = Assert.Throws<InvalidOperationException>(() => database.FindByUsername(username));

            Assert.AreEqual("No user is present by this username!", exception.Message, "FindByUsername method should throw an exception if person with that username not exists!");
        }

        [Test]
        public void DatabaseFindByIdMethodShouldFindCorrectPerson()
        {
            Assert.AreEqual(person, database.FindById(person.Id));
        }

        [TestCase(-1)]
        public void DatabaseFindByIdMethodShouldThrowAnExceptionWhenIdIsNotPositiveNumber(long id)
        {
            ArgumentOutOfRangeException exception = Assert.Throws<ArgumentOutOfRangeException>(() => database.FindById(id));

            Assert.AreEqual("Id should be a positive number!", exception.ParamName, "FindById method should throw an exception if id is not a positive number");
        }

        [TestCase(22)]
        public void DatabaseFindByIsMethodShouldThrowAnExceptionWhenIdDoesNotExist(long id)
        {
            InvalidOperationException exception = Assert.Throws<InvalidOperationException>(() => database.FindById(id));

            Assert.AreEqual("No user is present by this ID!", exception.Message, "FindById method should throw an exception if person with that id does not exist");
        }
    }
}