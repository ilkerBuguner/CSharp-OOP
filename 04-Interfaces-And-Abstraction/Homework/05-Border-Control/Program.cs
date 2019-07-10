using System;
using System.Collections.Generic;
using System.Linq;

namespace Border_Control
{
    public class Program
    {
        public static void Main(string[] args)
        {
            List<IIdentifiable> entries = new List<IIdentifiable>();

            while (true)
            {
                string command = Console.ReadLine();

                if (command == "End")
                {
                    break;
                }

                string[] tokens = command.Split();

                if (tokens.Length == 3)
                {
                    string name = tokens[0];
                    int age = int.Parse(tokens[1]);
                    string id = tokens[2];

                    IIdentifiable citizen = new Citizen(name, age, id);
                    entries.Add(citizen);
                }
                else
                {
                    string model = tokens[0];
                    string id = tokens[1];
                    IIdentifiable robot = new Robot(model, id);
                    entries.Add(robot);
                }
            }

            string digits = Console.ReadLine();

            List<IIdentifiable> toRemove = entries.Where(x => x.Id.EndsWith(digits)).ToList();

            foreach (var entry in toRemove)
            {
                Console.WriteLine(entry.Id);
            }
        }
    }
}
