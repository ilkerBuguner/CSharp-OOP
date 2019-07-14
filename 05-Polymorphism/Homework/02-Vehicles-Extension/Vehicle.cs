using System;
using System.Collections.Generic;
using System.Text;


public abstract class Vehicle : IVehicle
{
    private double fuelQuantity;

    public double FuelQuantity
    {
        get => fuelQuantity;
        set
        {
            if (value > TankCapacity)
            {
                fuelQuantity = 0;
            }
            else
            {
                fuelQuantity = value;
            }
        }
    }

    public double FuelConsumption { get; set; }
    public double TankCapacity { get; set; }

    public Vehicle(double fuelQuantity, double fuelConsumption, double capacity)
    {
        TankCapacity = capacity;
        FuelQuantity = fuelQuantity;
        FuelConsumption = fuelConsumption;
    }

    public virtual string Drive(double distance)
    {
        if (FuelConsumption * distance > FuelQuantity)
        {
            return $"{GetType()} needs refueling";
        }

        FuelQuantity -= FuelConsumption * distance;

        return $"{GetType()} travelled {distance} km";
    }

    public virtual string Refuel(double fuel)
    {
        if (fuel <= 0)
        {
            return "Fuel must be a positive number";
        }
        if (FuelQuantity + fuel > TankCapacity)
        {
            return $"Cannot fit {fuel} fuel in the tank";
        }

        FuelQuantity += fuel;

        return null;
    }
}



