using System;


public class Program
{
    public static void Main(string[] args)
    {
        string[] carInfo = Console.ReadLine().Split();

        double fuelQuantity = double.Parse(carInfo[1]);
        double fuelConsumption = double.Parse(carInfo[2]);

        Car car = new Car(fuelQuantity, fuelConsumption);

        string[] truckInfo = Console.ReadLine().Split();

        double fuelQuantityOfTruck = double.Parse(truckInfo[1]);
        double fuelConsumptionOfTruck = double.Parse(truckInfo[2]);

        Truck truck = new Truck(fuelQuantityOfTruck, fuelConsumptionOfTruck);

        int timesToRead = int.Parse(Console.ReadLine());

        for (int i = 0; i < timesToRead; i++)
        {
            string input = Console.ReadLine();
            string[] tokens = input.Split();

            if (input.Contains("Drive Car"))
            {
                double distance = double.Parse(tokens[2]);
                Console.WriteLine(car.Drive(distance));
            }
            else if (input.Contains("Drive Truck"))
            {
                double distance = double.Parse(tokens[2]);
                Console.WriteLine(truck.Drive(distance));
            }
            else if (input.Contains("Refuel Car"))
            {
                double fuel = double.Parse(tokens[2]);
                car.Refuel(fuel);
            }
            else if (input.Contains("Refuel Truck"))
            {
                double fuel = double.Parse(tokens[2]);
                truck.Refuel(fuel);
            }
        }

        Console.WriteLine($"Car: {car.FuelQuantity:F2}");
        Console.WriteLine($"Truck: {truck.FuelQuantity:F2}");
    }
}

