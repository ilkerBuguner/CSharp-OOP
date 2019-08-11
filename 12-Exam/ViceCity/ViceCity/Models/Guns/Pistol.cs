using System;
using System.Collections.Generic;
using System.Text;

namespace ViceCity.Models.Guns
{
    public class Pistol : Gun
    {
        private const int BULLETS_PER_BARREL = 10;
        private const int TOTAL_BULLETS = 100;
        private const int BulletsPerShoot = 1;
        public Pistol(string name) : base(name, BULLETS_PER_BARREL, TOTAL_BULLETS)
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
