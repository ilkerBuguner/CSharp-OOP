using System;
using System.Collections.Generic;

namespace _05._Football_Team_Generator
{
    public class Program
    {
        public static void Main(string[] args)
        {
            Dictionary<string, Team> teams = new Dictionary<string, Team>();

            while (true)
            {
                string input = Console.ReadLine();

                if (input == "END")
                {
                    break;
                }

                string[] tokens = input.Split(";", StringSplitOptions.RemoveEmptyEntries);

                try
                {
                    if (tokens[0] == "Team")
                    {
                        string teamName = tokens[1];
                        Team currentTeam = new Team(teamName);
                        teams.Add(teamName, currentTeam);
                    }
                    else if (tokens[0] == "Add")
                    {
                        string teamNameToAddInto = tokens[1];
                        if (teams.ContainsKey(teamNameToAddInto))
                        {
                            string playerName = tokens[2];
                            int endurance = int.Parse(tokens[3]);
                            int sprint = int.Parse(tokens[4]);
                            int dribble = int.Parse(tokens[5]);
                            int passing = int.Parse(tokens[6]);
                            int shooting = int.Parse(tokens[7]);

                            Player currentPlater = new Player(playerName, endurance, sprint,
                                dribble, passing, shooting);

                            teams[teamNameToAddInto].AddPlayer(currentPlater);
                        }
                        else
                        {
                            Console.WriteLine($"Team {teamNameToAddInto} does not exist.");
                        }
                    }
                    else if (tokens[0] == "Remove")
                    {
                        string teamName = tokens[1];
                        string playerName = tokens[2];
                        if (teams.ContainsKey(teamName))
                        {
                            teams[teamName].RemovePlayer(playerName);
                        }
                    }
                    else if (tokens[0] == "Rating")
                    {
                        string teamName = tokens[1];
                        if (teams.ContainsKey(teamName))
                        {
                            teams[teamName].CalculateRating();
                            Console.WriteLine($"{teamName} - {teams[teamName].Rating}");
                        }
                        else
                        {
                            Console.WriteLine($"Team {teamName} does not exist.");
                        }
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
