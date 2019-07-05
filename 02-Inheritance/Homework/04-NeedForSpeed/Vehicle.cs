using System;
using System.Collections.Generic;
using System.Text;

namespace NeedForSpeed
{
    public class Vehicle
    {
        private const double defaultFuelConsumption = 1.25;
        public virtual double FuelConsumption => defaultFuelConsumption;
        public double Fuel { get; set; }
        public int HorsePower { get; set; }
        public virtual void Drive(double kilometers)
        {
            double fuelNeeded = FuelConsumption * kilometers;
            if (Fuel >= fuelNeeded)
            {
                Fuel -= FuelConsumption * kilometers;

            }
        }
        public Vehicle(int horsePower, double fuel)
        {
            Fuel = fuel;
            HorsePower = horsePower;
        }


    }
}
