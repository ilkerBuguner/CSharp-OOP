using MXGP.Core.Contracts;
using System;
using System.Collections.Generic;
using System.Text;

namespace MXGP.Core
{
    public class Engine
    {
        ChampionshipController controller;
        public Engine()
        {
            controller = new ChampionshipController();
        }

        public void Run()
        {

            while (true)
            {
                string input = Console.ReadLine();

                if (input == "End")
                {
                    break;
                }

                string[] inputArgs = input.Split();

                string command = inputArgs[0];

                try
                {
                    if (command == "CreateRider")
                    {
                        string name = inputArgs[1];
                        Console.WriteLine(controller.CreateRider(name));
                    }
                    else if (command == "CreateMotorcycle")
                    {
                        string type = inputArgs[1];
                        string model = inputArgs[2];
                        int horsePower = int.Parse(inputArgs[3]);

                        Console.WriteLine(controller.CreateMotorcycle(type, model, horsePower));
                    }
                    else if (command == "AddMotorcycleToRider")
                    {
                        string riderName = inputArgs[1];
                        string motorcycleName = inputArgs[2];

                        Console.WriteLine(controller.AddMotorcycleToRider(riderName, motorcycleName));
                    }
                    else if (command == "AddRiderToRace")
                    {
                        string raceName = inputArgs[1];
                        string riderName = inputArgs[2];

                        Console.WriteLine(controller.AddRiderToRace(raceName, riderName));
                    }
                    else if (command == "CreateRace")
                    {
                        string name = inputArgs[1];
                        int laps = int.Parse(inputArgs[2]);

                        Console.WriteLine(controller.CreateRace(name, laps));
                    }
                    else if (command == "StartRace")
                    {
                        string raceName = inputArgs[1];

                        Console.WriteLine(controller.StartRace(raceName));
                    }
                }
                catch (Exception ex)
                {
                    Console.WriteLine(ex.Message);
                }
            }
        }
    }
}
