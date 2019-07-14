using System;
using System.Collections.Generic;
using System.Text;

class Truck : Vehicle
{

    public Truck(double fuelQuantity, double fuelConsumption, double capacity) : base(fuelQuantity, fuelConsumption, capacity)
    {
        base.FuelConsumption += 1.6;
    }

    public override string Refuel(double fuel)
    {
        base.Refuel(fuel);

        return base.Refuel(fuel);
    }
}

