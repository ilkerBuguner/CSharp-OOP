using MortalEngines.Core.Contracts;
using System;
using System.Collections.Generic;
using System.Text;

namespace MortalEngines.Core
{
    public class Engine : IEngine
    {
        private MachinesManager machineManager;

        public Engine()
        {
            machineManager = new MachinesManager();
        }
        public void Run()
        {
            while (true)
            {
                string input = Console.ReadLine();

                if (input == "Quit")
                {
                    break;
                }

                string[] tokens = input.Split();
                string command = tokens[0];
                try
                {
                    if (command == "HirePilot")
                    {
                        string name = tokens[1];
                        Console.WriteLine(machineManager.HirePilot(name));
                    }
                    else if (command == "PilotReport")
                    {
                        string name = tokens[1];
                        Console.WriteLine(machineManager.PilotReport(name));
                    }
                    else if (command == "ManufactureTank")
                    {
                        string name = tokens[1];
                        double attackPoints = double.Parse(tokens[2]);
                        double defensePoints = double.Parse(tokens[3]);
                        Console.WriteLine(machineManager.ManufactureTank(name, attackPoints, defensePoints));
                    }
                    else if (command == "ManufactureFighter")
                    {
                        string name = tokens[1];
                        double attackPoints = double.Parse(tokens[2]);
                        double defensePoints = double.Parse(tokens[3]);
                        Console.WriteLine(machineManager.ManufactureFighter(name, attackPoints, defensePoints));
                    }
                    else if (command == "MachineReport")
                    {
                        string name = tokens[1];
                        Console.WriteLine(machineManager.MachineReport(name));
                    }
                    else if (command == "AggressiveMode")
                    {
                        string name = tokens[1];
                        Console.WriteLine(machineManager.ToggleFighterAggressiveMode(name));
                    }
                    else if (command == "DefenseMode")
                    {
                        string name = tokens[1];
                        Console.WriteLine(machineManager.ToggleTankDefenseMode(name));
                    }
                    else if (command == "Engage")
                    {
                        string pilotName = tokens[1];
                        string machineName = tokens[2];
                        Console.WriteLine(machineManager.EngageMachine(pilotName, machineName));
                    }
                    else if (command == "Attack")
                    {
                        string attackingMachine = tokens[1];
                        string defendingMachine = tokens[2];
                        Console.WriteLine(machineManager.AttackMachines(attackingMachine, defendingMachine));
                    }
                }
                catch (Exception ex)
                {
                    Console.WriteLine($"Error: {ex.Message}");
                }
            }
        }
    }
}
