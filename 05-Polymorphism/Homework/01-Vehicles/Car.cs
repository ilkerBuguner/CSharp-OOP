using System;
using System.Collections.Generic;
using System.Text;


class Car : Vehicle
{
    public Car(double fuelQuantity, double fuelConsumption) : base(fuelQuantity, fuelConsumption)
    {
        base.FuelConsumption += 0.9;
    }


}

