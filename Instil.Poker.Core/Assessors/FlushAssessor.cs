using System.Linq;
using Instil.Poker.Core.Enums;
using Instil.Poker.Core.Utils;
using Instil.Poker.Domain.Enums;
using Instil.Poker.Domain.Interfaces;

namespace Instil.Poker.Core.Assessors
{
    /// <summary>
    /// Determins if the current hand is a Flush.
    /// Flush: Five cards all of the same suit, but not of sequential rank.
    /// </summary>
    public sealed class FlushAssessor : BasePokerHandAssessor
    {
        public override PokerHandType Assess(IPokerHand hand)
        {
            // All cards must be the same suit
            if (hand.Cards.AreAllSameSuit())
            {
                if (!hand.Cards.AreSequential())
                {
                    // Check Aces don't affect whether cards are sequential
                    if (hand.Cards.Any(card => card.Value == CardValue.Ace))
                    {
                        var otherCards = hand.Cards.Where(card => card.Value != CardValue.Ace);

                        if (!(otherCards.AreSequential()
                            && otherCards.Any(card => card.Value == CardValue.Two || card.Value == CardValue.King)))
                        {
                            return PokerHandType.Flush;
                        }
                    }
                    else
                    {
                        return PokerHandType.Flush;
                    }
                }
            }

            return base.Assess(hand);
        }
    }
}