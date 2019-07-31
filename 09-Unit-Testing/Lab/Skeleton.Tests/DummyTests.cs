using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Text;

namespace Skeleton.Tests
{
    [TestFixture]
    public class DummyTests
    {
        [Test]
        public void DummyLosesHealthWhenAttacked()
        {
            Axe axe = new Axe(5, 10);
            Dummy dummy = new Dummy(10, 10);

            //axe.Attack(dummy);
            dummy.TakeAttack(axe.AttackPoints);

            Assert.That(dummy.Health, Is.EqualTo(5), "Duumy doesnt lose health after attack.");
        }

        [Test]
        public void DeadDummyThrowsExceptionIfAttacked()
        {
            Axe axe = new Axe(5, 10);
            Dummy dummy = new Dummy(0, 10);


            Assert.That(() => dummy.TakeAttack(axe.AttackPoints)
            , Throws.InvalidOperationException.With.Message.EqualTo("Dummy is dead."));
        }

        [Test]
        public void DeadDummyCanGiveXP()
        {
            Dummy dummy = new Dummy(0, 10);

            int expectedXP = 10;

            Assert.That(dummy.GiveExperience(), Is.EqualTo(expectedXP)
                , "Dead dummy doesnt give XP");
        }

        [Test]
        public void AliveDummyCantGiveXP()
        {
            Dummy dummy = new Dummy(5, 10);

            Assert.That(() => dummy.GiveExperience()
            , Throws.InvalidOperationException.With.Message.EqualTo("Target is not dead."));
        }
    }
}
