using System;
using System.Linq;


public class StartUp
{
    static void Main(string[] args)
    {
        int[] pointsArgs = ArrayReader();

        Point topLeft = new Point(pointsArgs[0], pointsArgs[1]);
        Point bottomRight = new Point(pointsArgs[2], pointsArgs[3]);
        Rectangle rectangle = new Rectangle(topLeft, bottomRight);

        int timesToRead = int.Parse(Console.ReadLine());

        for (int i = 0; i < timesToRead; i++)
        {
            int[] currentPointInfo = ArrayReader();
            Point currentPoint = new Point(currentPointInfo[0], currentPointInfo[1]);

            Console.WriteLine(rectangle.Contains(currentPoint));
        }
    }

    public static int[] ArrayReader()
    {
        return Console.ReadLine().Split().Select(int.Parse).ToArray();
    }
}

