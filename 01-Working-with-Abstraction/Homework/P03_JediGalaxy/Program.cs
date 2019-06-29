using System;
using System.Linq;

namespace P03_JediGalaxy
{
    class Program
    {
        static void Main()
        {
            int[] dimestions = ReadArray();

            int x = dimestions[0];
            int y = dimestions[1];

            int[,] matrix = new int[x, y];

            int value = 0;
            for (int i = 0; i < x; i++)
            {
                for (int j = 0; j < y; j++)
                {
                    matrix[i, j] = value++;
                }
            }

            string command = Console.ReadLine();
            long sum = 0;
            while (command != "Let the Force be with you")
            {
                int[] ivoS = command
                    .Split(new string[] { " " }, StringSplitOptions.RemoveEmptyEntries)
                    .Select(int.Parse)
                    .ToArray();
                int[] evil = ReadArray();
                int xE = evil[0];
                int yE = evil[1];
                EvilPathMaker(matrix, ref xE, ref yE);

                int xI = ivoS[0];
                int yI = ivoS[1];
                IvoPathMaker(matrix, ref sum, ref xI, ref yI);

                command = Console.ReadLine();
            }

            Console.WriteLine(sum);

        }

        private static void IvoPathMaker(int[,] matrix, ref long sum, ref int xI, ref int yI)
        {
            while (xI >= 0 && yI < matrix.GetLength(1))
            {
                if (xI >= 0 && xI < matrix.GetLength(0) && yI >= 0 && yI < matrix.GetLength(1))
                {
                    sum += matrix[xI, yI];
                }

                yI++;
                xI--;
            }
        }

        private static void EvilPathMaker(int[,] matrix, ref int xE, ref int yE)
        {
            while (xE >= 0 && yE >= 0)
            {
                if (xE >= 0 && xE < matrix.GetLength(0) && yE >= 0 && yE < matrix.GetLength(1))
                {
                    matrix[xE, yE] = 0;
                }
                xE--;
                yE--;
            }
        }

        private static int[] ReadArray()
        {
            return Console.ReadLine()
                .Split(new string[] { " " }, StringSplitOptions.RemoveEmptyEntries)
                .Select(int.Parse)
                .ToArray();
        }
    }
}
