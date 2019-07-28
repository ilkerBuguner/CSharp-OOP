using System;

namespace Enter_Number
{
    class Program
    {
        static void Main(string[] args)
        {
            for (int i = 0; i < 10; i++)
            {
                string input = Console.ReadLine();

                try
                {
                    ReadNumber(input);
                }
                catch (ArgumentException ae)
                {
                    Console.WriteLine(ae.Message);;
                    i = 0;
                }
                catch (FormatException fe)
                {
                    Console.WriteLine(fe.Message);
                    i = 0;
                }
            }
        }

        public static void ReadNumber(string number)
        {
            int num = 0;

            int.TryParse(number, out num);

            if (num != 0)
            {
                if (num < 1 || num > 100)
                {
                    throw new ArgumentException("Invalid number");
                }
            }
            else if (num == 0)
            {
                throw new FormatException("Invalid input");
            }

            Console.WriteLine(num);

        }
    }
}
