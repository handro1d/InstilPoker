using Instil.Poker.Core.Enums;
using Instil.Poker.Core.Interfaces;
using Instil.Poker.Domain.Interfaces;

namespace Instil.Poker.Core.Assessors
{
    public abstract class BasePokerHandAssessor : IPokerHandAssessor
    {
        private IPokerHandAssessor _nextHandler;

        public IPokerHandAssessor SetNext(IPokerHandAssessor handler)
        {
            _nextHandler = handler;
            return handler;
        }

        public virtual PokerHandType Assess(IPokerHand hand)
        {
            return _nextHandler != null
                ? _nextHandler.Assess(hand)
                : PokerHandType.HighCard;
        }
    }
}