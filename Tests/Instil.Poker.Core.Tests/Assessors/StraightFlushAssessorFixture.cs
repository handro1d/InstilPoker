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
    internal sealed class StraightFlushAssessorFixture
    {
        private StraightFlushAssessor _assessor;

        [SetUp]
        public void SetUp()
        {
            _assessor = new StraightFlushAssessor();
        }

        [Test]
        public void Assess_ShouldReturnHighCardForHandContainingDuplicateRanks()
        {
            var cards = new List<Card>
            {
                new Card(CardValue.Two, CardSuit.Clubs),
                new Card(CardValue.Two, CardSuit.Spades),
                new Card(CardValue.Four, CardSuit.Spades),
                new Card(CardValue.Six, CardSuit.Diamonds),
                new Card(CardValue.Queen, CardSuit.Clubs)
            };

            var hand = new FakePokerHand().WithCards(cards);

            var result = _assessor.Assess(hand.Object);

            Assert.AreEqual(PokerHandType.HighCard, result);
        }

        [Test]
        public void Assess_ShouldReturnHighCardForMultipleSuits()
        {
            var cards = new List<Card>
            {
                new Card(CardValue.Two, CardSuit.Clubs),
                new Card(CardValue.Six, CardSuit.Clubs),
                new Card(CardValue.Four, CardSuit.Diamonds),
                new Card(CardValue.Five, CardSuit.Clubs),
                new Card(CardValue.Three, CardSuit.Hearts)
            };

            var hand = new FakePokerHand().WithCards(cards);

            var result = _assessor.Assess(hand.Object);

            Assert.AreEqual(PokerHandType.HighCard, result);
        }

        [Test]
        public void Assess_ShouldIdentifyStraightWithoutAce()
        {
            var cards = new List<Card>
            {
                new Card(CardValue.Two, CardSuit.Clubs),
                new Card(CardValue.Six, CardSuit.Clubs),
                new Card(CardValue.Four, CardSuit.Clubs),
                new Card(CardValue.Five, CardSuit.Clubs),
                new Card(CardValue.Three, CardSuit.Clubs)
            };

            var hand = new FakePokerHand().WithCards(cards);

            var result = _assessor.Assess(hand.Object);

            Assert.AreEqual(PokerHandType.StraightFlush, result);
        }

        [Test]
        public void Assess_ShouldIdentifyStraightWithLowAce()
        {
            var cards = new List<Card>
            {
                new Card(CardValue.Two, CardSuit.Clubs),
                new Card(CardValue.Ace, CardSuit.Clubs),
                new Card(CardValue.Four, CardSuit.Clubs),
                new Card(CardValue.Five, CardSuit.Clubs),
                new Card(CardValue.Three, CardSuit.Clubs)
            };

            var hand = new FakePokerHand().WithCards(cards);

            var result = _assessor.Assess(hand.Object);

            Assert.AreEqual(PokerHandType.StraightFlush, result);
        }

        [Test]
        public void Assess_ShouldIdentifyRoyalFlush()
        {
            var cards = new List<Card>
            {
                new Card(CardValue.Ten, CardSuit.Clubs),
                new Card(CardValue.Ace, CardSuit.Clubs),
                new Card(CardValue.Queen, CardSuit.Clubs),
                new Card(CardValue.King, CardSuit.Clubs),
                new Card(CardValue.Jack, CardSuit.Clubs)
            };

            var hand = new FakePokerHand().WithCards(cards);

            var result = _assessor.Assess(hand.Object);

            Assert.AreEqual(PokerHandType.RoyalFlush, result);
        }
    }
}
