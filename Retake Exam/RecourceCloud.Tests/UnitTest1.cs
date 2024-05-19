using NUnit.Framework;
using System;
using System.Linq;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace RecourceCloud.Tests
{
    public class Tests
    {
        private DepartmentCloud departmentCloud;

        [SetUp]
        public void Setup()
        {
            departmentCloud = new DepartmentCloud();
        }

        [Test]
        public void ConstructonShouldWorkCorrectlyAndSetTasksAndResourcesCollections()
        {
            Assert.IsNotNull(departmentCloud);
            Assert.IsInstanceOf<DepartmentCloud>(departmentCloud);
            Assert.IsNotNull(departmentCloud.Tasks);
            Assert.IsNotNull(departmentCloud.Resources);
        }

        [Test]
        public void LogTaskMethodShouldLogTaskCorrectly()
        {
            Assert.AreEqual("Task logged successfully.", departmentCloud.LogTask(new string[] { "1", "new task", "local" }));

            Assert.AreEqual(1, departmentCloud.Tasks.Count);
        }

        [Test]
        public void LogTaskMethodShouldNotLogTaskWithSameResourceName()
        {
            departmentCloud.LogTask(new string[] { "1", "new task", "local" });
            string result = departmentCloud.LogTask(new string[] { "2", "another task", "local" });

            Assert.AreEqual(1, departmentCloud.Tasks.Count);
            Assert.AreEqual("local is already logged.", result);
        }

        [Test]
        public void LogTaskMethodShouldThrowAnExceptionIfArgumentsAreNotThree()
        {
            ArgumentException exception = Assert.Throws<ArgumentException>(() => departmentCloud.LogTask(new string[] { "1", "new task" }));

            Assert.AreEqual("All arguments are required.", exception.Message);
        }

        [TestCase("1", null, "local")]
        [TestCase(null, "new task", "local")]
        [TestCase("1", "new task", null)]
        public void LogTaskMethodShouldThrowAnExceptionIfAnyOfArgumentsIsNull(string arg1, string arg2, string arg3)
        {
            string[] arguments = new string[] { arg1, arg2, arg3 };

            ArgumentException exception = Assert.Throws<ArgumentException>(() => departmentCloud.LogTask(new string[] { "1", null, "local" }));

            Assert.AreEqual("Arguments values cannot be null.", exception.Message);
        }

        [Test]
        public void CreateResourceMethodShouldAddResourceAndRemoveTaskCorrectlyAndReturnTrue()
        {
            departmentCloud.LogTask(new string[] { "1", "new task", "local" });

            Assert.IsTrue(departmentCloud.CreateResource());
            Assert.AreEqual(0, departmentCloud.Tasks.Count);
            Assert.AreEqual(1, departmentCloud.Resources.Count);
        }

        [Test]
        public void CreateResourceMethodShouldReturnNullWhenTaskCollectionIsEmpty()
        {
            Assert.IsFalse(departmentCloud.CreateResource());
        }

        [Test]
        public void TestResourceMethodShouldTestAndReturnCorrectResource()
        {
            departmentCloud.LogTask(new string[] { "1", "new task", "local" });
            departmentCloud.CreateResource();

            Assert.IsTrue(departmentCloud.TestResource("local").IsTested);
            Assert.IsNotNull(departmentCloud.TestResource("local"));
        }

        [Test]
        public void TestResourceMethodShouldReturnNullWhenResourceWithGivenNameNotExist()
        {
            departmentCloud.LogTask(new string[] { "1", "new task", "local" });
            departmentCloud.CreateResource();

            Assert.IsNull(departmentCloud.TestResource("name does not exist"));
        }
    }
}