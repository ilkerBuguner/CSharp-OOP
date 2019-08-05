using NUnit.Framework;
using System;
using System.Collections.Generic;

namespace TheRace.Tests
{
    public class RaceEntryTests
    {
        RaceEntry raceEntry;

       [SetUp]
        public void Setup()
        {
            raceEntry = new RaceEntry();
        }

        [Test]
        public void TestIfAddRiderCommandWorksCorrectly()
        {
            int expectedRaceEntryCount = 1;
            UnitMotorcycle motorcycle = new UnitMotorcycle("Suzuki", 100, 1000);

            UnitRider rider = new UnitRider("ilko", motorcycle);

            raceEntry.AddRider(rider);

            Assert.AreEqual(expectedRaceEntryCount, raceEntry.Counter);
        }

        [Test]
        public void TestIfAddRiderCommandThrowsErrorWithInvalidUnitRider()
        {
            UnitRider rider = null;

            Assert.Throws<InvalidOperationException>(() => raceEntry.AddRider(rider));
        }

        [Test]
        public void TestIfAddRiderCommandThrowsErrorWithAlreadyExistRider()
        {
            UnitMotorcycle motorcycle = new UnitMotorcycle("Suzuki", 100, 1000);

            UnitRider rider = new UnitRider("ilko", motorcycle);

            raceEntry.AddRider(rider);

            Assert.Throws<InvalidOperationException>(() => raceEntry.AddRider(rider));
        }

        [Test]
        public void TestIfCalculateAverageHorsePowerCommandWorksCorrectly()
        {
            double expectedAverageHP = 100;
            UnitMotorcycle motorcycle = new UnitMotorcycle("Suzuki", 100, 1000);
            UnitMotorcycle secondMotorcycle = new UnitMotorcycle("Porti", 100, 1000);

            UnitRider rider = new UnitRider("ilko", motorcycle);
            UnitRider secondRider = new UnitRider("Sasho", secondMotorcycle);

            raceEntry.AddRider(rider);
            raceEntry.AddRider(secondRider);

            double averageHP = raceEntry.CalculateAverageHorsePower();

            Assert.AreEqual(expectedAverageHP, averageHP);
        }

        [Test]
        public void TestIfCalculateAverageHorsePowerThrowsErrorWithLowCountOfParticipans()
        {
            UnitMotorcycle motorcycle = new UnitMotorcycle("Suzuki", 100, 1000);
            UnitRider rider = new UnitRider("ilko", motorcycle);
            raceEntry.AddRider(rider);

            Assert.Throws<InvalidOperationException>(() => raceEntry.CalculateAverageHorsePower());
        }
    }
}