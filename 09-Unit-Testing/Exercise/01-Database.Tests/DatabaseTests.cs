//using Database;
using NUnit.Framework;
using System;

namespace Tests
{
    public class DatabaseTests
    {
        private Database database;
        private readonly int[] initialData = new int[] { 1, 2 };

        [SetUp]
        public void Setup()
        {
            this.database = new Database(initialData);
        }

        [Test]
        public void TestIfConstructorWorksCorrectly()
        {
            int expectedCount = 2;

            Assert.AreEqual(expectedCount, database.Count);
        }

        [Test]
        public void TestAddingCorrectly()
        {
            this.database.Add(3);

            int expectedCount = 3;

            Assert.AreEqual(expectedCount, database.Count);
        }

        [Test]
        public void TestAddingWhenFull()
        {
            for (int i = 3; i <= 16; i++)
            {
                database.Add(i);
            }

            Assert.That(() => database.Add(17), Throws.InvalidOperationException);
        }

        [Test]
        public void TestRemoveCorrectly()
        {
            int expectedCount = 1;

            database.Remove();

            Assert.AreEqual(expectedCount, database.Count);
        }

        [Test]
        public void TestRemovingWhenEmpty()
        {
            for (int i = 0; i < 2; i++)
            {
                database.Remove();
            }

            Assert.Throws<InvalidOperationException>(database.Remove);
        }

        [Test]
        public void TestFetchMethod()
        {
            int[] result = database.Fetch();

            CollectionAssert.AreEqual(initialData, result);
        }
    }
}