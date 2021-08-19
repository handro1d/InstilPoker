using Instil.Poker.Domain.Interfaces;
using Instil.Poker.Domain.Utils;
using System.Collections.Generic;
using System.Linq;

namespace Instil.Poker.Domain.Entities
{
    public class DefaultPokerHand : IPokerHand
    {
        public IEnumerable<Card> Cards { get; }

        public DefaultPokerHand(IEnumerable<Card> cards)
        {
            Cards = cards;
        }

        public override string ToString()
        {
            var cardRepresentations = Cards.Select(c => $"{c.Value.GetDescription()}{c.Suit.GetDescription()}");
            return string.Join(" ", cardRepresentations);
        }
    }
}