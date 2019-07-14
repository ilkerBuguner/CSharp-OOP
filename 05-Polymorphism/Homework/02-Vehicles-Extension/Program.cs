using System;

public class Program
{
    public static void Main(string[] args)
    {
        string[] carInfo = Console.ReadLine().Split(" ", StringSplitOptions.RemoveEmptyEntries);

        double fuelQuantity = double.Parse(carInfo[1]);
        double fuelConsumption = double.Parse(carInfo[2]);
        double tankCapacity = double.Parse(carInfo[3]);

        Car car = new Car(fuelQuantity, fuelConsumption, tankCapacity);

        string[] truckInfo = Console.ReadLine().Split(" ", StringSplitOptions.RemoveEmptyEntries);

        double truckFuelQuantity = double.Parse(truckInfo[1]);
        double truckFuelConsumption = double.Parse(truckInfo[2]);
        double truckTankCapacity = double.Parse(truckInfo[3]);

        Truck truck = new Truck(truckFuelQuantity, truckFuelConsumption, truckTankCapacity);

        string[] busInfo = Console.ReadLine().Split(" ", StringSplitOptions.RemoveEmptyEntries);

        double busFuelQuantity = double.Parse(busInfo[1]);
        double busFuelConsumption = double.Parse(busInfo[2]);
        double busTankCapacity = double.Parse(busInfo[3]);

        Bus bus = new Bus(busFuelQuantity, busFuelConsumption, busTankCapacity);

        int timesToRead = int.Parse(Console.ReadLine());

        for (int i = 0; i < timesToRead; i++)
        {
            string input = Console.ReadLine();
            string[] tokens = input.Split(" ", StringSplitOptions.RemoveEmptyEntries);

            if (tokens[0] == "Drive")
            {
                double distance = double.Parse(tokens[2]);

                if (tokens[1] == "Car")
                {
                    Console.WriteLine(car.Drive(distance));
                }
                else if (tokens[1] == "Truck")
                {
                    Console.WriteLine(truck.Drive(distance));
                }
                else if (tokens[1] == "Bus")
                {
                    Console.WriteLine(bus.Drive(distance));
                }
            }
            else if (tokens[0] == "DriveEmpty")
            {
                double distance = double.Parse(tokens[2]);
                Console.WriteLine(bus.DriveEmpty(distance));
            }
            else if (tokens[0] == "Refuel")
            {
                double fuel = double.Parse(tokens[2]);
                if (tokens[1] == "Car")
                {
                    string res = car.Refuel(fuel);

                    if (res != null)
                    {
                        Console.WriteLine(car.Refuel(fuel));
                    }
                }
                else if (tokens[1] == "Truck")
                {
                    string res = truck.Refuel(fuel);

                    if (res != null)
                    {
                        Console.WriteLine(truck.Refuel(fuel));
                    }
                }
                else if (tokens[1] == "Bus")
                {
                    string res = bus.Refuel(fuel);

                    if (res != null)
                    {
                        Console.WriteLine(bus.Refuel(fuel));
                    }
                }
            }
           
        }

        Console.WriteLine($"Car: {car.FuelQuantity:F2}");
        Console.WriteLine($"Truck: {truck.FuelQuantity:F2}");
        Console.WriteLine($"Bus: {bus.FuelQuantity:F2}");
    }
}

