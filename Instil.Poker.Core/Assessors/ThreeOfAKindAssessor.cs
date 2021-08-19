using System.Linq;
using Instil.Poker.Core.Enums;
using Instil.Poker.Domain.Interfaces;

namespace Instil.Poker.Core.Assessors
{
    /// <summary>
    /// Determines if the current hand is Three of a Kind.
    /// Three of a Kind: 3 cards of 1 rank, and 2 cards of 2 other ranks
    /// </summary>
    public sealed class ThreeOfAKindAssessor : BasePokerHandAssessor
    {
        public override PokerHandType Assess(IPokerHand hand)
        {
            var ranks = hand.Cards.GroupBy(card => card.Value);

            // 3 different ranks should be contained
            // One rank should have 3 occurences
            if (ranks.Count() == 3 && ranks.Any(rank => rank.Count() == 3))
            {
                return PokerHandType.ThreeOfAKind;
            }

            return base.Assess(hand);
        }
    }
}