using ExtendedDatabase;
using NUnit.Framework;
using System;

namespace Tests
{
    public class ExtendedDatabaseTests
    {
        private static Person[] persons;

        private ExtendedDatabase.ExtendedDatabase database;

        [SetUp]
        public void Setup()
        {
            persons = new Person[] { new Person(0, "ilko"), new Person(1, "Emre") };

            database = new ExtendedDatabase.ExtendedDatabase(persons);

        }

        [Test]
        public void TestConstructorWorksCorrectly()
        {
            int expectedCount = 2;
            Person[] expectedPersonsInDatabase = persons;

            Assert.AreEqual(expectedCount, database.Count);
        }

        //[Test]
        //public void TestAddRangeWorksCorrectly()
        //{
        //    Person[] expectedPersons = new Person[16];
        //    expectedPersons[0] = new Person(0, "ilko");
        //    expectedPersons[1] = new Person(1, "Emre");

        //    Assert.That(database.Persons, Is.EqualTo(expectedPersons));
        //}

        [Test]
        public void TestIfAddWorksCorrectly()
        {
            Person expectedPerson = new Person(3, "Pesho");

            database.Add(expectedPerson);

            Assert.AreEqual(expectedPerson, database.Persons[2]);
        }

        [Test]
        public void TestAddingWhenArraysCapacityIsFull()
        {
            Person person1 = new Person(2, "Gosho");
            Person person2 = new Person(3, "sfas");

            database.Add(person1);
            database.Add(person2);
            database.Add(new Person(4, "fgs"));
            database.Add(new Person(5, "rgfer"));
            database.Add(new Person(6, "bgf"));
            database.Add(new Person(7, "vwef"));
            database.Add(new Person(8, "yhjt"));
            database.Add(new Person(9, "qwe"));
            database.Add(new Person(10, "mjh"));
            database.Add(new Person(11, "qwrq"));
            database.Add(new Person(12, "jty"));
            database.Add(new Person(13, "adv"));
            database.Add(new Person(14, "rk"));
            database.Add(new Person(15, "weg"));

            Assert.Throws<InvalidOperationException>(() =>
            {
                database.Add(new Person(16, "error"));
            });
        }

        [Test]
        public void TestAddingTwoPersonsWithSameUsernames()
        {
            Assert.Throws<InvalidOperationException>(() =>
            {
                database.Add(new Person(2, "ilko"));
            });
        }

        [Test]
        public void TestAddingTwoPersonsWithSameId()
        {
            Assert.Throws<InvalidOperationException>(() =>
            {
                database.Add(new Person(1, "Pesho"));
            });
        }

        [Test]
        public void TestRemoveMethodWorksCorrectly()
        {
            int expectedCount = database.Count - 1;

            database.Remove();

            Assert.AreEqual(expectedCount, database.Count);
            Assert.AreEqual(null, database.Persons[expectedCount]);
        }

        [Test]
        public void TestIfFindByUsernameMethodWorksCorrectly()
        {
            Person expectedPerson = database.Persons[0];

            Person actualPerson = database.FindByUsername("ilko");

            Assert.AreEqual(expectedPerson, actualPerson);
        }

        [Test]
        public void TestFindByUsernameMethodWithNullArgument()
        {
            Assert.Throws<ArgumentNullException>(() =>
            {
                database.FindByUsername(null);
            });
        }

        [Test]
        public void TestFindByUsernameMethodWithIncorectUsername()
        {
            Assert.Throws<InvalidOperationException>(() =>
            {
                database.FindByUsername("Pesho");
            });
        }

        [Test]
        public void TestIfFindByIdMethodWorksCorrectly()
        {
            Person expectedPerson = persons[0];

            Person actualPerson = database.FindById(0);

            Assert.AreEqual(expectedPerson, actualPerson);
        }

        [Test]
        public void TestFindByIdMethodWithNegativeId()
        {
            Assert.Throws<ArgumentOutOfRangeException>(() =>
            {
                database.FindById(-2);
            });
        }

        [Test]
        public void TestFindByIdMethodWithInvalidId()
        {
            Assert.Throws<InvalidOperationException>(() =>
            {
                database.FindById(4);
            });
        }
    }
}