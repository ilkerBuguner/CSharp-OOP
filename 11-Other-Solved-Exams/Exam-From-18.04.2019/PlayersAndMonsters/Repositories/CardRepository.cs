using PlayersAndMonsters.Models.Cards.Contracts;
using PlayersAndMonsters.Repositories.Contracts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace PlayersAndMonsters.Repositories
{
    public class CardRepository : ICardRepository
    {
        private readonly List<ICard> cards;
        public int Count => Cards.Count;

        public CardRepository()
        {
            cards = new List<ICard>();
        }

        public IReadOnlyCollection<ICard> Cards => cards.AsReadOnly();

        public void Add(ICard card)
        {
            if (card == null)
            {
                throw new ArgumentException("Card cannot be null!");
            }

            foreach (var cardInGame in cards)
            {
                if (cardInGame.Name == card.Name)
                {
                    throw new ArgumentException($"Card {card.Name} already exists!");
                }
            }

            cards.Add(card);
        }

        public ICard Find(string name)
        {
            return cards.FirstOrDefault(x => x.Name == name);
        }

        public bool Remove(ICard card)
        {
            if (card == null)
            {
                throw new ArgumentException("Card cannot be null!");
            }

            if (cards.Contains(card))
            {
                cards.Remove(card);
                return true;
            }

            return false;
        }
    }
}
