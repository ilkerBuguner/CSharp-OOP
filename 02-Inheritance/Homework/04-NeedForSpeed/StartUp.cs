namespace NeedForSpeed
{
    public class StartUp
    {
        public static void Main(string[] args)
        {
            SportCar car = new SportCar(300, 20);

            System.Console.WriteLine(car.FuelConsumption);
            car.Drive(2);

        }
    }
}
