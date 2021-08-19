using System.Collections.Generic;
using Instil.Poker.Domain.Entities;
using Instil.Poker.Domain.Interfaces;
using Moq;

namespace Instil.Poker.Core.Tests.Fakes
{
    internal sealed class FakePokerHand : Mock<IPokerHand>
    {
        public FakePokerHand WithCards(IEnumerable<Card> cards)
        {
            SetupGet(x => x.Cards).Returns(cards);

            return this;
        }
    }
}