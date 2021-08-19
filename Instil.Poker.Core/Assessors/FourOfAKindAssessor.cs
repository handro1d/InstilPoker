using Instil.Poker.Core.Enums;
using Instil.Poker.Domain.Interfaces;
using System.Linq;

namespace Instil.Poker.Core.Assessors
{
    /// <summary>
    /// Determine if the current hand is Four of a Kind.
    /// Four of a kind: hand that contains four cards of one rank and one card of another.
    /// </summary>
    public sealed class FourOfAKindAssessor : BasePokerHandAssessor
    {
        public override PokerHandType Assess(IPokerHand hand)
        {
            var ranks = hand.Cards.GroupBy(card => card.Value);

            if (ranks.Count() == 2)
            {
                if (ranks.Any(x => x.Count() == 4))
                {
                    return PokerHandType.FourOfAKind;
                }
            }

            return base.Assess(hand);
        }
    }
}
