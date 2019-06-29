using System;

namespace Lab___1._Rhombus_of_Stars
{
    class Program
    {
        static void Main(string[] args)
        {
            int size = int.Parse(Console.ReadLine());

            for (int i = 1; i <= size; i++)
            {
                PrintRow(i, size);
            }
            for (int i = size - 1; i >= 1; i--)
            {
                PrintRow(i, size);
            }
        }

        private static void PrintRow(int i, int size)
        {
            int spacesCount = size - i;
            for (int j = 0; j < spacesCount; j++)
            {
                Console.Write(" ");
            }
            for (int k = 1; k < i; k++)
            {
                Console.Write("* ");
            }
            Console.WriteLine("*");
        }
    }
}
