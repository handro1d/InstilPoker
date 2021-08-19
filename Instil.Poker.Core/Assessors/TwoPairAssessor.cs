using System.Linq;
using Instil.Poker.Core.Enums;
using Instil.Poker.Domain.Interfaces;

namespace Instil.Poker.Core.Assessors
{
    /// <summary>
    /// Determines if the current hand is Two Pair.
    /// Two Pair: 2 cards of 1 rank, 2 cards of another rank and remaining cards of other ranks
    /// </summary>
    public sealed class TwoPairAssessor : BasePokerHandAssessor
    {
        public override PokerHandType Assess(IPokerHand hand)
        {
            var duplicatedRanks = hand.Cards
                .GroupBy(card => card.Value)
                .Where(group => group.Count() >= 2);

            // Only two card ranks should have 2 or more occurences
            if (duplicatedRanks.Count() == 2)
            {
                // Duplicated ranks must only have 2 occurences
                if (duplicatedRanks.All(duplicatedRank => duplicatedRank.Count() == 2))
                {
                    return PokerHandType.TwoPair;
                }
            }

            return base.Assess(hand);
        }
    }
}