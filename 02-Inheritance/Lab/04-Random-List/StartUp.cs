using System;

namespace CustomRandomList
{
    public class StartUp
    {
        static void Main(string[] args)
        {
            RandomList randomList = new RandomList();
            for (int i = 0; i < 100; i++)
            {
                randomList.Add(i.ToString());
            }

            for (int i = 0; i < 10; i++)
            {
                Console.WriteLine(randomList.RandomString());
            }
        }
    }
}
