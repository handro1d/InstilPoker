using Instil.Poker.Core.Assessors;
using Instil.Poker.Core.Enums;
using Instil.Poker.Core.Exceptions;
using Instil.Poker.Core.Interfaces;
using Instil.Poker.Domain.Interfaces;
using System;

namespace Instil.Poker.Core
{
    public sealed class PokerFace : IPokerHandDetermination
    {
        private readonly IHandValidator _handValidator;

        public PokerFace(IHandValidator handValidator)
        {
            _handValidator = handValidator ?? throw new ArgumentNullException(nameof(handValidator));
        }

        public PokerHandType DetermineHand(IPokerHand pokerHand)
        {
            var validationResult = _handValidator.Validate(pokerHand);

            if (!validationResult.Succeeded)
            {
                throw new InvalidHandException($"{validationResult.Error} Hand: {pokerHand}");
            }

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