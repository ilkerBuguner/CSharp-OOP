using System;
using System.Collections.Generic;
using System.Text;

class Truck : Vehicle
{
    public Truck(double fuelQuantity, double fuelConsumption) : base(fuelQuantity, fuelConsumption)
    {
        base.FuelConsumption += 1.6;
    }

    public override void Refuel(double fuel)
    {
        fuel = fuel * 95 / 100;
        base.Refuel(fuel);
    }
}

