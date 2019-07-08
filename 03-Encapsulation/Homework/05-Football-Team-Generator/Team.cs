using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace _05._Football_Team_Generator
{
    public class Team
    {
        private string name;

        private List<Player> players;

        public string Name
        {
            get => name;
            private set
            {
                if (string.IsNullOrEmpty(value) || string.IsNullOrWhiteSpace(value))
                {
                    throw new ArgumentException("A name should not be empty.");
                }
                name = value;
            }
        }

        public Team(string name)
        {
            Name = name;
            players = new List<Player>();
        }
        public double Rating { get; private set; }

        public void CalculateRating()
        {
            double totalPlayersOverallSkill = 0;
            if (players.Count > 0)
            {
                Rating = (int)Math.Round(players.Average(x => x.Stats));
            }
            else
            {
                Rating = (int)totalPlayersOverallSkill;
            }

        }

        public void RemovePlayer(string name)
        {
            Player player = players.FirstOrDefault(x => x.Name == name);

            if (player != null)
            {
                players.Remove(player);
            }
            else
            {
                Console.WriteLine($"Player {name} is not in {Name} team.");
            }
        }

        public void AddPlayer(Player player)
        {
            players.Add(player);
        }
    }
}
