﻿using PlayersAndMonsters.Models.Players.Contracts;
using PlayersAndMonsters.Repositories.Contracts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace PlayersAndMonsters.Repositories
{
    public class PlayerRepository : IPlayerRepository
    {
        private readonly List<IPlayer> players;
        public int Count => Players.Count;

        public PlayerRepository()
        {
            players = new List<IPlayer>();
        }
        public IReadOnlyCollection<IPlayer> Players => players.AsReadOnly();

        public void Add(IPlayer player)
        {
            if (player == null)
            {
                throw new ArgumentException("Player cannot be null");
            }

            foreach (var playerInGame in players)
            {
                if (playerInGame.Username == player.Username)
                {
                    throw new ArgumentException($"Player {player.Username} already exists!");
                }
            }

            players.Add(player);
        }

        public IPlayer Find(string username)
        {
            return players.FirstOrDefault(x => x.Username == username);
        }

        public bool Remove(IPlayer player)
        {
            if (player == null)
            {
                throw new ArgumentException("Player cannot be null");
            }

            if (players.Contains(player))
            {
                players.Remove(player);
                return true;
            }

            return false;
        }
    }
}
