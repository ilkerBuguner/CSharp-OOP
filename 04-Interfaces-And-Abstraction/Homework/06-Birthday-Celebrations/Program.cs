using System;
using System.Collections.Generic;
using System.Linq;

namespace Border_Control
{
    public class Program
    {
        public static void Main(string[] args)
        {
            List<IBirthable> birthables = new List<IBirthable>();

            while (true)
            {
                string command = Console.ReadLine();

                if (command == "End")
                {
                    break;
                }

                string[] tokens = command.Split();

                if (tokens[0] == "Citizen")
                {
                    string name = tokens[1];
                    int age = int.Parse(tokens[2]);
                    string id = tokens[3];
                    string birthdate = tokens[4];

                    IBirthable citizen = new Citizen(name, age, id, birthdate);
                    birthables.Add(citizen);
                }
                else if (tokens[0] == "Pet")
                {
                    string name = tokens[1];
                    string birthdate = tokens[2];

                    IBirthable pet = new Pet(name, birthdate);
                    birthables.Add(pet);
                }
            }

            int year = int.Parse(Console.ReadLine());

            List<IBirthable> birthablesWithSpecificYear = new List<IBirthable>();

            foreach (var birthable in birthables)
            {
                if (birthable.BirthYear == year)
                {
                    birthablesWithSpecificYear.Add(birthable);
                }
            }

            foreach (var birthable in birthablesWithSpecificYear)
            {
                Console.WriteLine(birthable.Birthdate);
            }


        }
    }
}
