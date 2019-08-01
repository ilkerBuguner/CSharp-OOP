using FightingArena;
using NUnit.Framework;
using System;

namespace Tests
{
    public class ArenaTests
    {
        private Arena arena;
        [SetUp]
        public void Setup()
        {
            arena = new Arena();
        }

        [Test]
        public void TestIfConstructorIsWorkingCorrectly()
        {
            Assert.IsNotNull(arena.Warriors);
        }

        [Test]
        public void TestEnrollWorksCorrectly()
        {
            int expectedCount = 1;
            Warrior warrior = new Warrior("Pesho", 15, 100);

            arena.Enroll(warrior);

            Assert.AreEqual(expectedCount, arena.Count);
        }

        [Test]
        public void TestEnrollingExistingWarrior()
        {
            Warrior warrior = new Warrior("Pesho", 15, 100);

            arena.Enroll(warrior);

            Assert.Throws<InvalidOperationException>(() => arena.Enroll(warrior));
        }

        [Test]
        public void TestIfFightMethodWorksCorrectly()
        {
            int expectedAttackerHP = 85;
            int expectedEnemyHP = 85;

            Warrior attacker = new Warrior("Pesho", 15, 100);
            Warrior enemy = new Warrior("Gosho", 15, 100);

            arena.Enroll(attacker);
            arena.Enroll(enemy);

            arena.Fight("Pesho", "Gosho");

            Assert.AreEqual(expectedAttackerHP, attacker.HP);
            Assert.AreEqual(expectedEnemyHP, enemy.HP);

        }

        [Test]
        public void TestFightMethodWithIncorrectWarriors()
        {
            Warrior attacker = new Warrior("Pesho", 15, 100);

            arena.Enroll(attacker);

            Assert.Throws<InvalidOperationException>(() => arena.Fight("Pesho", "ilko"));


        }
    }
}
