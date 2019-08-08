namespace ParkingSystem.Tests
{
    using NUnit.Framework;
    using System;

    public class SoftParkTest
    {
        SoftPark parking;
        [SetUp]
        public void Setup()
        {
            parking = new SoftPark();
        }

        [Test]
        public void TestIfConstructorWorksCorrectly()
        {
            int expectedParkSpotCount = 12;

            Assert.AreEqual(expectedParkSpotCount, parking.Parking.Count);
        }

        [Test]
        public void TestIfParkCarCommandWorksCorrectly()
        {
            Car car = new Car("VW", "1157");

            parking.ParkCar("A1", car);

            Assert.NotNull(parking.Parking["A1"]);
        }

        [Test]
        public void TestIfParkCarCommandThrowsExceptionWithInvalidParkSpot()
        {
            Car car = new Car("VW", "1157");


            Assert.Throws<ArgumentException>(() => parking.ParkCar("Invalid", car));
        }

        [Test]
        public void TestIfParkCarCommandThrowsExceptionWhenCarSpotIsAlreadyTaken()
        {
            Car car = new Car("VW", "1157");
            Car newCar = null;

            parking.ParkCar("A1", car);

            Assert.Throws<ArgumentException>(() => parking.ParkCar("A1", newCar));
        }

        [Test]
        public void TestIfParkCarCommandThrowsExceptionWhenCarIsAlreadyParked()
        {
            Car car = new Car("VW", "1157");

            parking.ParkCar("A1", car);

            Assert.Throws<InvalidOperationException>(() => parking.ParkCar("A2", car));
        }

        [Test]
        public void TestIfRemoveCarCommandWorksCorrectly()
        {
            Car car = new Car("VW", "1157");

            parking.ParkCar("A1", car);

            parking.RemoveCar("A1", car);

            Assert.IsNull(parking.Parking["A1"]);
        }

        [Test]
        public void TestIfRemoveCarCommandThrowsExceptionWhenCarSpotDoesntExist()
        {
            Car car = new Car("VW", "1157");

            Assert.Throws<ArgumentException>(() => parking.RemoveCar("Invalid", car));
        }

        [Test]
        public void TestIfRemoveCarCommandThrowsExeptionWhenCarFromInputIsDifferent()
        {
            Car car = new Car("VW", "1157");
            Car newCar = null;

            parking.ParkCar("A1", car);

            Assert.Throws<ArgumentException>(() => parking.RemoveCar("A1", newCar));
        }
    }
}