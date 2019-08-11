namespace BlueOrigin.Tests
{
    using System;
    using NUnit.Framework;

    public class SpaceshipTests
    {
       [Test]
       public void TestConstructorWorksCorrectly()
        {
            string name = "Korab";
            int capacity = 10;

            string expectedName = name;
            int expectedCapacity = capacity;
            int expectedShipCount = 0;
            
            Spaceship ship = new Spaceship(name, capacity);

            Assert.AreEqual(expectedName, ship.Name);
            Assert.AreEqual(expectedCapacity, ship.Capacity);
            Assert.AreEqual(expectedShipCount, ship.Count);
        }
        
        [Test]
        public void TestIfInvalidNameThrowsException()
        {
            string name = null;
            int capacity = 10;

            Assert.Throws<ArgumentNullException>(() => new Spaceship(name, capacity));
        }

        [Test]
        public void TestIfEmptyNameThrowsException()
        {
            string name = "";
            int capacity = 10;

            Assert.Throws<ArgumentNullException>(() => new Spaceship(name, capacity));
        }
        [Test]
        public void TestIfNegativeCapacityThrowsException()
        {
            string name = "Korab";
            int capacity = -10;

            Assert.Throws<ArgumentException>(() => new Spaceship(name, capacity));
        }

        [Test]
        public void TestAddWorksCorrectly()
        {
            string name = "Korab";
            int capacity = 10;
            Astronaut astronaut1 = new Astronaut("Pesho", 1.4);
            Spaceship ship = new Spaceship(name, capacity);

            ship.Add(astronaut1);
            int expectedAstronoutsCount = 1;

            Assert.AreEqual(expectedAstronoutsCount, ship.Count);
        }

        [Test]
        public void TestIfAddThrowsExceptionWhenReachCapacity()
        {
            string name = "Korab";
            int capacity = 0;
            Astronaut astronaut1 = new Astronaut("Pesho", 1.4);
            Spaceship ship = new Spaceship(name, capacity);

            Assert.Throws<InvalidOperationException>(() => ship.Add(astronaut1));
        }

        [Test]
        public void TestIfAddThrowsExceptionWithExcistingAstronout()
        {
            string name = "Korab";
            int capacity = 10;
            Astronaut astronaut1 = new Astronaut("Pesho", 1.4);
            Spaceship ship = new Spaceship(name, capacity);
            ship.Add(astronaut1);

            Assert.Throws<InvalidOperationException>(() => ship.Add(astronaut1));
        }

        [Test]
        public void TestIfRemoveWorksCorrectly()
        {
            string name = "Korab";
            int capacity = 10;
            Astronaut astronaut1 = new Astronaut("Pesho", 1.4);
            Spaceship ship = new Spaceship(name, capacity);
            ship.Add(astronaut1);

            ship.Remove("Pesho");
            int expectedCount = 0;

            Assert.AreEqual(expectedCount, ship.Count);


        }

        
    }
}