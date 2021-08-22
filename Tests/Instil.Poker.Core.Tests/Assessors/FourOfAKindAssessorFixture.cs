using Instil.Poker.Core.Assessors;
using Instil.Poker.Core.Enums;
using Instil.Poker.Core.Tests.Fakes;
using Instil.Poker.Domain.Entities;
using Instil.Poker.Domain.Enums;
using NUnit.Framework;
using System.Collections.Generic;

namespace Instil.Poker.Core.Tests.Assessors
{
    [TestFixture]
    internal sealed class FourOfAKindAssessorFixture
    {
        private FourOfAKindAssessor _assessor;

        [SetUp]
        public void SetUp()
        {
            _assessor = new FourOfAKindAssessor();
        }

        [Test]
        public void Assess_ShouldReturnHighCardForMultipleRanks()
        {
            var cards = new List<Card>
            {
                new Card(CardValue.Two, CardSuit.Hearts),
                new Card(CardValue.Four, CardSuit.Hearts),
                new Card(CardValue.Six, CardSuit.Diamonds),
                new Card(CardValue.Eight, CardSuit.Hearts),
                new Card(CardValue.Jack, CardSuit.Clubs)
            };

            var hand = new FakePokerHand().WithCards(cards);

            var result = _assessor.Assess(hand.Object);

            Assert.AreEqual(PokerHandType.HighCard, result);
        }

        [Test]
        public void Assess_ShouldReturnHighCardForInvalidRankCount()
        {
            var cards = new List<Card>
            {
                new Card(CardValue.Two, CardSuit.Hearts),
                new Card(CardValue.Two, CardSuit.Clubs),
                new Card(CardValue.Two, CardSuit.Diamonds),
                new Card(CardValue.Eight, CardSuit.Hearts),
                new Card(CardValue.Eight, CardSuit.Clubs)
            };

            var hand = new FakePokerHand().WithCards(cards);

            var result = _assessor.Assess(hand.Object);

            Assert.AreEqual(PokerHandType.HighCard, result);
        }

        [Test]
        public void Assess_ShouldIdentifyFourOfAKind()
        {
            var cards = new List<Card>
            {
                new Card(CardValue.Two, CardSuit.Hearts),
                new Card(CardValue.Two, CardSuit.Clubs),
                new Card(CardValue.Two, CardSuit.Diamonds),
                new Card(CardValue.Two, CardSuit.Spades),
                new Card(CardValue.Eight, CardSuit.Clubs)
            };

            var hand = new FakePokerHand().WithCards(cards);

            var result = _assessor.Assess(hand.Object);

            Assert.AreEqual(PokerHandType.FourOfAKind, result);
        }
    }
}
