using System.Collections.Generic;
using System.Linq;
using Instil.Poker.Domain.Entities;
using Instil.Poker.Domain.Enums;

namespace Instil.Poker.Tests.Common
{
    public static class CardUtility
    {
        /// <summary>
        /// Create random Card object.
        /// </summary>
        /// <param name="suitsToExclude">Any suit(s) which should not be considered for random Card.</param>
        /// <param name="ranksToExclude">Any rank(s) which should not be considered for random Card.</param>
        /// <returns>Random <cref="Card" /> object.</returns>
        public static Card GenerateRandomCard(
            IEnumerable<CardSuit> suitsToExclude = null,
            IEnumerable<CardValue> ranksToExclude = null)
        {
            var randomSuit = EnumUtility.GetRandomEnumValue<CardSuit>(suitsToExclude);
            var randomValue = EnumUtility.GetRandomEnumValue<CardValue>(ranksToExclude);

            return new Card(randomValue, randomSuit);
        }

        /// <summary>
        /// Create set of random Card objects.
        /// </summary>
        /// <param name="numberOfCardsToGenerate">Number of Cards to create</param>
        /// <param name="suitsToExclude">Any suit(s) which should not be considered for random Card.</param>
        /// <param name="valuesToExclude">Any rank(s) which should not be considered for random Card.</param>
        /// <returns><cref="IEnumerable" /> of random <cref="Card" /> objects.</returns>
        public static IEnumerable<Card> GenerateRandomCards(
            int numberOfCardsToGenerate, 
            IEnumerable<CardSuit> suitsToExclude = null,
            IEnumerable<CardValue> valuesToExclude = null)
        {
            return Enumerable
                .Range(1, numberOfCardsToGenerate)
                .Select(x => GenerateRandomCard(suitsToExclude));
        }
    }
}