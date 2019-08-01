using FightingArena;
using NUnit.Framework;
using System;

namespace Tests
{
    public class WarriorTests
    {
        [SetUp]
        public void Setup()
        {
        }

        [Test]
        public void TestIfConstructorWorksCorrectly()
        {
            string expectedName = "Pesho";
            int expectedDamage = 15;
            int expectedHp = 100;

            Warrior warrior = new Warrior(expectedName, expectedDamage, expectedHp);

            Assert.AreEqual(expectedName, warrior.Name);
            Assert.AreEqual(expectedDamage, warrior.Damage);
            Assert.AreEqual(expectedHp, warrior.HP);
        }

        [Test]
        public void TestCreatingWarriorWithNullName()
        {
            Assert.Throws<ArgumentException>(() =>
            {
                Warrior warrior = new Warrior(null, 15, 100);
            });
        }

        [Test]
        public void TestCreatingWarriorWithNegativeDamage()
        {
            Assert.Throws<ArgumentException>(() =>
            {
                Warrior warrior = new Warrior("Pesho", -2, 100);
            });
        }

        [Test]
        public void TestCreatingWarriorWithNegativeHP()
        {
            Assert.Throws<ArgumentException>(() =>
            {
                Warrior warrior = new Warrior("Pesho", 15, -32);
            });
        }

        [Test]
        public void TestIfAttackMethodWorksCorrectly()
        {
            int expectedAttackerHP = 50;
            int expectedEnemyHP = 0;

            Warrior attacker = new Warrior("Pesho", 40, 100);
            Warrior enemy = new Warrior("Gosho", 50, 35);

            attacker.Attack(enemy);

            Assert.AreEqual(expectedAttackerHP, attacker.HP);
            Assert.AreEqual(expectedEnemyHP, enemy.HP);
        }

        [Test]
        public void TestIfAttackerHpIsLowerThan30()
        {
            //Warrior(string name, int damage, int hp)

            Warrior attacker = new Warrior("Pesho", 40, 20);
            Warrior enemy = new Warrior("Gosho", 50, 35);

            Assert.Throws<InvalidOperationException>(() => attacker.Attack(enemy));
        }

        [Test]
        public void TestIfEnemyHpIsLowerThan30()
        {
            Warrior attacker = new Warrior("Pesho", 40, 100);
            Warrior enemy = new Warrior("Gosho", 50, 20);

            Assert.Throws<InvalidOperationException>(() => attacker.Attack(enemy));
        }

        [Test]
        public void TestIfAttackerHpIsLowerThanEnemyDamagePoins()
        {
            Warrior attacker = new Warrior("Pesho", 40, 30);
            Warrior enemy = new Warrior("Gosho", 50, 100);

            Assert.Throws<InvalidOperationException>(() => attacker.Attack(enemy));
        }
    }
}