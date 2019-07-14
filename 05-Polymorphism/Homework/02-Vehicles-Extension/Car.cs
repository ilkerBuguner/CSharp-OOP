using System;
using System.Collections.Generic;
using System.Text;


class Car : Vehicle
{
    
    public Car(double fuelQuantity, double fuelConsumption, double capacity) : base(fuelQuantity, fuelConsumption, capacity)
    {
        base.FuelConsumption += 0.9;

    }
}

