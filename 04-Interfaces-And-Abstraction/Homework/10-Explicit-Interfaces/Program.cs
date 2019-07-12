using System;

namespace Explicit_Interfaces
{
    public class Program
    {
        public static void Main(string[] args)
        {
            while (true)
            {
                string command = Console.ReadLine();

                if (command == "End")
                {
                    break;
                }

                string[] tokens = command.Split();

                string name = tokens[0];
                string country = tokens[1];
                string age = tokens[2];

                IPerson p = new Citizen(name, country, age);
                IResident person = new Citizen(name, country, age);

                Console.WriteLine(p.GetName());
                Console.WriteLine(person.GetName());

            }
        }
    }
}
