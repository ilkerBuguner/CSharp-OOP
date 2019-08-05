using System;
using System.Collections.Generic;
using System.Text;

namespace MXGP.Models.Motorcycles
{
    public class PowerMotorcycle : Motorcycle
    {
        //private int minHP = 70;
        //private int maxHP = 100;
        private const double CurrentCubicCentimeters = 450;
        public PowerMotorcycle(string model, int horsePower) : base(model, horsePower, CurrentCubicCentimeters)
        {
            minHP = 70;
            maxHP = 100;
        }
    }
}
