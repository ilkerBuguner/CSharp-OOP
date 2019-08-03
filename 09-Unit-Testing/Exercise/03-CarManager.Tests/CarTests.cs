using CarManager;
using NUnit.Framework;
using System;

namespace Tests
{
    public class CarTests
    {
        [SetUp]
        public void Setup()
        {
        }

        [Test]
        public void TestIfConstructorWorksCorrectly()
        {
            string expectedMake = "Audi";
            string expectedModel = "A4";
            int expectedFuelConsumption = 7;
            int expectedFuelCapacity = 60;
            int expectedFuelAmount = 0;
            Car car = new Car("Audi", "A4", 7, 60);

            Assert.AreEqual(expectedMake, car.Make);
            Assert.AreEqual(expectedModel, car.Model);
            Assert.AreEqual(expectedFuelConsumption, car.FuelConsumption);
            Assert.AreEqual(expectedFuelCapacity, car.FuelCapacity);
            Assert.AreEqual(expectedFuelAmount, car.FuelAmount);
        }

        [Test]
        public void TestIfMakePropThrowsExceptionWithInvalidArgument()
        {
            Car car = null;
            Assert.Throws<ArgumentException>(() => car = new Car(null, "A4", 7, 60));
        }

        [Test]
        public void TestIfModelPropThrowsExceptionWithInvalidArgument()
        {
            Car car = null;
            Assert.Throws<ArgumentException>(() => car = new Car("Audi", null, 7, 60));
        }

        [Test]
        public void TestIfFuelConsumptionPropThrowsExceptionWithInvalidArgument()
        {
            Car car = null;
            Assert.Throws<ArgumentException>(() => car = new Car("Audi", "A4", -10, 60));
        }


        //Fuel Amount prop isnt tested..

        [Test]
        public void TestIfFuelCapacityPropThrowsExceptionWithInvalidArgument()
        {
            Car car = null;
            Assert.Throws<ArgumentException>(() => car = new Car("Audi", "A4", 7, -10));
        }

        [Test]
        public void TestIfRefuelMethodWorksCorrectly()
        {
            int expectedFuelAmount = 20;

            Car car = new Car("Audi", "A4", 7, 60);
            car.Refuel(20);

            Assert.AreEqual(expectedFuelAmount, car.FuelAmount);
        }

        [Test]
        public void TestIfRefuelMethodWorksFineWithOverRefuel()
        {
            int expectedFuelAmount = 60;
            Car car = new Car("Audi", "A4", 7, 60);

            car.Refuel(59);
            car.Refuel(100);

            Assert.AreEqual(expectedFuelAmount, car.FuelAmount);

        }

        [Test]
        public void TestIfRefuelMethodThrowsExceptionWhenInputIsInvalid()
        {
            Car car = new Car("Audi", "A4", 7, 60);


            Assert.Throws<ArgumentException>(() => car.Refuel(-20));
        }

        [Test]
        public void TestIfDriveMethodWorksCorrectly()
        {
            double expectedFuelAmount = 28.6;

            Car car = new Car("Audi", "A4", 7, 60);
            car.Refuel(30);

            car.Drive(20);

            Assert.AreEqual(expectedFuelAmount, car.FuelAmount);
        }

        [Test]
        public void TestIfDriveMethodThrowsExceptionWithInvalidArgument()
        {
            Car car = new Car("Audi", "A4", 7, 60);

            Assert.Throws<InvalidOperationException>(() => car.Drive(20));
        }
    }
}