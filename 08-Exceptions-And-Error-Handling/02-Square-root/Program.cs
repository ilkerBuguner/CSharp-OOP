using System;

namespace Exceptions_And_Error_Handling___Lab
{
    class Program
    {
        static void Main(string[] args)
        {
            double number = double.Parse(Console.ReadLine());
            try
            {
                double num = GetSquareRoot(number);
                Console.WriteLine(num);
            }
            catch (InvalidOperationException ex)
            {
                Console.WriteLine(ex.Message);
            }
            finally
            {
                Console.WriteLine("Good bye");
            }
        }

        private static double GetSquareRoot(double number)
        {
            if (number == null || number < 0)
            {
                throw new InvalidOperationException("Invalid Number");
            }

            return Math.Sqrt(number);
        }
    }
}
