using PlayersAndMonsters.Core.Contracts;
using System;
using System.Collections.Generic;
using System.Text;

namespace PlayersAndMonsters.Core
{
    public class Engine : IEngine
    {
        private IManagerController managerController;

        public Engine()
        {
            managerController = new ManagerController();
        }
        public void Run()
        {
            while (true)
            {
                string input = Console.ReadLine();

                if (input == "Exit")
                {
                    break;
                }

                try
                {
                    string[] inputArgs = input.Split();
                    string command = inputArgs[0];

                    if (command == "AddPlayer")
                    {
                        string playerType = inputArgs[1];
                        string playerUsername = inputArgs[2];

                        Console.WriteLine(managerController.AddPlayer(playerType, playerUsername));
                    }
                    else if (command == "AddCard")
                    {
                        string cardType = inputArgs[1];
                        string cardName = inputArgs[2];

                        Console.WriteLine(managerController.AddCard(cardType, cardName));
                    }
                    else if (command == "AddPlayerCard")
                    {
                        string username = inputArgs[1];
                        string cardName = inputArgs[2];

                        Console.WriteLine(managerController.AddPlayerCard(username, cardName));
                    }
                    else if (command == "Fight")
                    {
                        string attackUser = inputArgs[1];
                        string enemyUser = inputArgs[2];

                        Console.WriteLine(managerController.Fight(attackUser, enemyUser));
                    }
                    else if (command == "Report")
                    {
                        Console.WriteLine(managerController.Report());
                    }
                }
                catch (ArgumentException ex)
                {
                    Console.WriteLine(ex.Message);
                }

                
            }
        }
    }
}
