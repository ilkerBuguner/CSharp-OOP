using PlayersAndMonsters.Core.Factories.Contracts;
using PlayersAndMonsters.Models.Cards.Contracts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;

namespace PlayersAndMonsters.Core.Factories
{
    public class CardFactory : ICardFactory
    {
        private const string Suffix = "Card";
        public ICard CreateCard(string type, string name)
        {
            var cardType = Assembly.GetExecutingAssembly().GetTypes().FirstOrDefault(t => t.Name == type + Suffix);

            if (cardType == null)
            {
                throw new ArgumentException("Invalid card type");
            }

            var card = (ICard)Activator.CreateInstance(cardType, name);

            return card;
        }
    }
}
