using Skeleton.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;

namespace Skeleton
{
    public class FakeWeapon : IWeapon
    {
        public int AttackPoints => 10;

        public int DurabilityPoints => throw new NotImplementedException();

        public void Attack(ITarget target)
        {
            target.TakeAttack(10);
        }
    }
}
