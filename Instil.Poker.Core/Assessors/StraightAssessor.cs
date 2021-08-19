using System.Linq;
using Instil.Poker.Core.Enums;
using Instil.Poker.Core.Utils;
using Instil.Poker.Domain.Enums;
using Instil.Poker.Domain.Interfaces;

namespace Instil.Poker.Core.Assessors
{
    /// <summary>
    /// Determines if the current hand is a Straight.
    /// Straight: Five cards of sequential rank, not the same suit.
    /// </summary>
    public class StraightAssessor : BasePokerHandAssessor
    {
        public override PokerHandType Assess(IPokerHand hand)
        {
            // All cards must not be the same suit
            if (hand.Cards.AreAllSameSuit())
            {
                return NoStraightIdentified(hand);
            }

            return DetermineStraight(hand) ?? NoStraightIdentified(hand);
        }

        protected PokerHandType? DetermineStraight(IPokerHand hand)
        {
            // Hand can contain no duplicates
            if (!DoesHandContainDuplicateRanks(hand))
            {
                // Numbers should be sequential
                if (hand.Cards.AreSequential())
                {
                    return PokerHandType.Straight;
                }

                // Numbers were not sequential - check for presence of Aces
                if (hand.Cards.Any(card => card.Value == CardValue.Ace))
                {
                    var otherCards = hand.Cards.Where(card => card.Value != CardValue.Ace);

                    if (otherCards.AreSequential())
                    {
                        // Remaining Cards are sequential
                        if (hand.Cards.Any(card => card.Value == CardValue.Two))
                        {
                            return PokerHandType.LowStraight;
                        }

                        if (hand.Cards.Any(card => card.Value == CardValue.King))
                        {
                            return PokerHandType.HighStraight;
                        }
                    }
                }
            }

            return null;
        }

        protected PokerHandType NoStraightIdentified(IPokerHand hand)
        {
            return base.Assess(hand);
        }

        private static bool DoesHandContainDuplicateRanks(IPokerHand pokerHand)
        {
            return pokerHand.Cards.GroupBy(card => card.Value).Count() != pokerHand.Cards.Count();
        }
    }
}