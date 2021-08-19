using Instil.Poker.Core.Assessors;
using Instil.Poker.Core.Enums;
using Instil.Poker.Core.Interfaces;
using Instil.Poker.Domain.Interfaces;

namespace Instil.Poker.Core
{
    public sealed class PokerFace : IPokerHandDetermination
    {
        public PokerHandType DetermineHand(IPokerHand pokerHand)
        {
            var flushAssessor = new FlushAssessor();
            var fourOfAKindAssessor = new FourOfAKindAssessor();
            var fullHouseAssessor = new FullHouseAssessor();
            var onePairAssessor = new OnePairAssessor();
            var straightAssessor = new StraightAssessor();
            var straightFlushAssessor = new StraightFlushAssessor();
            var threeOfAKindAssessor = new ThreeOfAKindAssessor();
            var twoPairAssessor = new TwoPairAssessor();

            // Configure chain of responsibility
            straightFlushAssessor
                .SetNext(fourOfAKindAssessor)
                .SetNext(fullHouseAssessor)
                .SetNext(flushAssessor)
                .SetNext(straightAssessor)
                .SetNext(threeOfAKindAssessor)
                .SetNext(twoPairAssessor)
                .SetNext(onePairAssessor);

            return straightFlushAssessor.Assess(pokerHand);
        }
    }
}