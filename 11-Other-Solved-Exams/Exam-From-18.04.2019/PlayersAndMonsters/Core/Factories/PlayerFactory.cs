using PlayersAndMonsters.Core.Factories.Contracts;
using PlayersAndMonsters.Models.Players.Contracts;
using System;
using System.Collections.Generic;
using System.Reflection;
using System.Text;
using System.Linq;
using PlayersAndMonsters.Repositories;

namespace PlayersAndMonsters.Core.Factories
{
    public class PlayerFactory : IPlayerFactory
    {
        public IPlayer CreatePlayer(string type, string username)
        {
            var playerType = Assembly.GetExecutingAssembly().GetTypes().FirstOrDefault(t => t.Name == type);

            if (playerType == null)
            {
                throw new ArgumentException("Invalid player type");
            }

            var repository = new CardRepository();

            var player = (IPlayer)Activator.CreateInstance(playerType,repository, username);

            return player;
        }
    }
}
