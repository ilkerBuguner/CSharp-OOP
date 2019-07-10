using System;
using System.Collections.Generic;
using System.Linq;

namespace Border_Control
{
    public class Program
    {
        public static void Main(string[] args)
        {
            Dictionary<string, IBuyer> buyers = new Dictionary<string, IBuyer>();

            int timesToRead = int.Parse(Console.ReadLine());

            for (int i = 0; i < timesToRead; i++)
            {
                string[] tokens = Console.ReadLine().Split();

                if (tokens.Length == 4)
                {
                    string name = tokens[0];
                    int age = int.Parse(tokens[1]);
                    string id = tokens[2];
                    string birthdate = tokens[3];

                    IBuyer citizen = new Citizen(name, age, id, birthdate);

                    buyers.Add(name, citizen);
                }
                else if (tokens.Length == 3)
                {
                    string name = tokens[0];
                    int age = int.Parse(tokens[1]);
                    string group = tokens[2];

                    IBuyer rebel = new Rebel(name, age, group);

                    buyers.Add(name, rebel);
                }
            }

            int totalFood = 0;

            while (true)
            {
                string command = Console.ReadLine();

                if (command == "End")
                {
                    break;
                }

                if (buyers.Any(x => x.Key == command))
                {
                    totalFood += buyers[command].BuyFood();
                }
            }

            Console.WriteLine(totalFood);


            


        }
    }
}
