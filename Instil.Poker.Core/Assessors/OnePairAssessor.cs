using System.Linq;
using Instil.Poker.Core.Enums;
using Instil.Poker.Domain.Interfaces;

namespace Instil.Poker.Core.Assessors
{
    /// <summary>
    /// Determines if the current hand is One Pair.
    /// One Pair: 2 cards of 1 rank and remaining cards of other ranks
    /// </summary>
    public sealed class OnePairAssessor : BasePokerHandAssessor
    {
        public override PokerHandType Assess(IPokerHand hand)
        {
            var duplicatedRanks = hand.Cards
                .GroupBy(card => card.Value)
                .Where(group => group.Count() >= 2);

            // Only one card rank should have 2 or more occurences
            if (duplicatedRanks.Count() == 1)
            {
                // Duplicated rank must only have 2 occurences
                if (duplicatedRanks.All(duplicatedRank => duplicatedRank.Count() == 2))
                {
                    return PokerHandType.OnePair;
                }
            }

            return base.Assess(hand);
        }
    }
}