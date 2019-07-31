using NUnit.Framework;
using Skeleton.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;

namespace Skeleton.Tests
{
    [TestFixture]
    public class HeroTests
    {
        [Test]
        public void HeroGainsXPAfterAttackIfTargetDies()
        {
            IWeapon weapon = new FakeWeapon();
            ITarget target = new FakeTarget();

            Hero hero = new Hero("Ilko", weapon);
            hero.Attack(target);
            int expectedXP = 20;


            Assert.That(hero.Experience, Is.EqualTo(expectedXP)
                , "Hero doesnt gain Xp after kill");
        }
    }
}
