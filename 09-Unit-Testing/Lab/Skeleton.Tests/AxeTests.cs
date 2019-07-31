﻿using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Text;

namespace Skeleton.Tests
{
    [TestFixture]
    public class AxeTests
    {
        [Test]
        public void AxeLosesDurabilityAfterAttack()
        {
            Axe axe = new Axe(10, 10);
            Dummy dummy = new Dummy(10, 10);

            axe.Attack(dummy);

            Assert.That(axe.DurabilityPoints, Is.EqualTo(9), "Axe doesnt lose durability after attack.");
        }

        [Test]
        public void AttackingWithBrokenAxeThrowsException()
        {
            Axe axe = new Axe(1,1);
            Dummy dummy = new Dummy(10, 10);

            axe.Attack(dummy);

            Assert.That(() => axe.Attack(dummy)
            , Throws.InvalidOperationException.With.Message.EqualTo("Axe is broken."));
        }
    }
}
