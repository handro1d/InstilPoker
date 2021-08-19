using Instil.Poker.Core.Enums;
using Instil.Poker.Core.Utils;
using Instil.Poker.Domain.Interfaces;

namespace Instil.Poker.Core.Assessors
{
    /// <summary>
    /// Determines if the current hand is a Straight Flush.
    /// Straight Flush: hand that contains five cards of sequential rank.
    /// </summary>
    public sealed class StraightFlushAssessor : StraightAssessor
    {
        public override PokerHandType Assess(IPokerHand hand)
        {
            var straight = DetermineStraight(hand);

            if (straight != null && hand.Cards.AreAllSameSuit())
            {
                return straight == PokerHandType.HighStraight 
                    ? PokerHandType.RoyalFlush
                    : PokerHandType.StraightFlush;
            }

            return NoStraightIdentified(hand);
        }
    }
}
