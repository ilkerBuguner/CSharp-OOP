using System;
using System.Collections.Generic;
using System.Text;

namespace ViceCity.Models.Guns
{
    public class Rifle : Gun
    {
        private const int BULLETS_PER_BARREL = 50;
        private const int TOTAL_BULLETS = 500;
        private const int BulletsPerShoot = 5;
        public Rifle(string name) : base(name, BULLETS_PER_BARREL, TOTAL_BULLETS)
        {
        }

        public override int Fire()
        {
            if (BulletsPerBarrel == 0)
            {
                if (TotalBullets > BULLETS_PER_BARREL)
                {
                    BulletsPerBarrel = BULLETS_PER_BARREL;
                    TotalBullets -= BulletsPerBarrel;
                }
                else
                {
                    BulletsPerBarrel = TotalBullets;
                    TotalBullets -= BulletsPerBarrel;
                }
            }

            if (BulletsPerShoot > BulletsPerBarrel)
            {
                int bulletsToReturn = BulletsPerBarrel;
                BulletsPerBarrel = 0;
                return bulletsToReturn;
            }

            BulletsPerBarrel -= BulletsPerShoot;

            return BulletsPerShoot;
        }
    }
}
