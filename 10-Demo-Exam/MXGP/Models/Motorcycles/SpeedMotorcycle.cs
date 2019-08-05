using System;
using System.Collections.Generic;
using System.Text;

namespace MXGP.Models.Motorcycles
{
    public class SpeedMotorcycle : Motorcycle
    {
        //private int minHP = 50;
        //private int maxHP = 69;
        private const int CurrentCubicCentimeters = 125;
        public SpeedMotorcycle(string model, int horsePower) : base(model, horsePower, CurrentCubicCentimeters)
        {
            minHP = 50;
            maxHP = 69;
        }
    }
}
