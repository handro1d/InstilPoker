using System.Collections.Generic;
using System.Linq;
using Instil.Poker.Domain.Entities;

namespace Instil.Poker.Core.Utils
{
    internal static class CardExtensions
    {
        /// <summary>
        /// Determines if all Cards in collection are of the same suit.
        /// </summary>
        /// <param name="cards">Card collection to analyse.</param>
        /// <returns>Boolean value indicating if all Cards are the same suit.</returns>
        public static bool AreAllSameSuit(this IEnumerable<Card> cards)
        {
            return cards.GroupBy(card => card.Suit).Count() == 1;
        }

        /// <summary>
        /// Determins if all Cards in collection are sequential.
        /// </summary>
        /// <param name="cards">Card collection to analyse.</param>
        /// <returns>Boolean value indicating if all Cards are sequential.</returns>
        public static bool AreSequential(this IEnumerable<Card> cards)
        {
            var orderedCards = cards.OrderBy(card => (int)card.Value);

            var firstCard = orderedCards.ElementAt(0);
            var lastCard = orderedCards.ElementAt(cards.Count() - 1);
            return (int)lastCard.Value - (int)firstCard.Value == orderedCards.Count() - 1;
        }
    }
}