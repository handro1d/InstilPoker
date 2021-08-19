using Instil.Poker.Core.Enums;
using Instil.Poker.Domain.Interfaces;
using System.Linq;

namespace Instil.Poker.Core.Assessors
{
    /// <summary>
    /// Determine if the current hand is a Full House.
    /// Full House: hand that contains three cards of one rank and two cards of another.
    /// </summary>
    public sealed class FullHouseAssessor : BasePokerHandAssessor
    {
        public override PokerHandType Assess(IPokerHand hand)
        {
            var ranks = hand.Cards.GroupBy(card => card.Value);

            if (ranks.Count() == 2)
            {
                if (ranks.Any(x => x.Count() == 3))
                {
                    return PokerHandType.FullHouse;
                }
            }

            return base.Assess(hand);
        }
    }
}
