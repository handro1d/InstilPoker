using System.Collections.Generic;
using Instil.Poker.Core.Assessors;
using Instil.Poker.Core.Enums;
using Instil.Poker.Core.Tests.Fakes;
using Instil.Poker.Domain.Entities;
using Instil.Poker.Domain.Enums;
using Instil.Poker.Tests.Common;
using NUnit.Framework;

namespace Instil.Poker.Core.Tests.Assessors
{
    [TestFixture]
    internal sealed class StraightAssessorFixture
    {
        private StraightAssessor _assessor;

        [SetUp]
        public void SetUp()
        {
            _assessor = new StraightAssessor();
        }

        [Test]
        public void Assess_ShouldReturnHighCardForHandOfOneSuit()
        {
            var suitExclusions = new List<CardSuit> { CardSuit.Diamonds, CardSuit.Spades, CardSuit.Clubs };
            var cards = CardUtility.GenerateRandomCards(5, suitsToExclude: suitExclusions);
            var hand = new FakePokerHand().WithCards(cards);

            var result = _assessor.Assess(hand.Object);

            Assert.AreEqual(PokerHandType.HighCard, result);
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
        public void Assess_ShouldIdentifyStraightWithoutAce()
        {
            var cards = new List<Card>
            {
                new Card(CardValue.Two, CardSuit.Clubs),
                new Card(CardValue.Six, CardSuit.Diamonds),
                new Card(CardValue.Four, CardSuit.Clubs),
                new Card(CardValue.Five, CardSuit.Spades),
                new Card(CardValue.Three, CardSuit.Clubs)
            };

            var hand = new FakePokerHand().WithCards(cards);

            var result = _assessor.Assess(hand.Object);

            Assert.AreEqual(PokerHandType.Straight, result);
        }

        [Test]
        public void Assess_ShouldIdentifyStraightWithLowAce()
        {
            var cards = new List<Card>
            {
                new Card(CardValue.Two, CardSuit.Clubs),
                new Card(CardValue.Ace, CardSuit.Diamonds),
                new Card(CardValue.Four, CardSuit.Clubs),
                new Card(CardValue.Five, CardSuit.Spades),
                new Card(CardValue.Three, CardSuit.Clubs)
            };

            var hand = new FakePokerHand().WithCards(cards);

            var result = _assessor.Assess(hand.Object);

            Assert.AreEqual(PokerHandType.LowStraight, result);
        }

        [Test]
        public void Assess_ShouldIdentifyStraightWithHighAce()
        {
            var cards = new List<Card>
            {
                new Card(CardValue.Ten, CardSuit.Clubs),
                new Card(CardValue.Ace, CardSuit.Diamonds),
                new Card(CardValue.Queen, CardSuit.Clubs),
                new Card(CardValue.King, CardSuit.Spades),
                new Card(CardValue.Jack, CardSuit.Clubs)
            };

            var hand = new FakePokerHand().WithCards(cards);

            var result = _assessor.Assess(hand.Object);

            Assert.AreEqual(PokerHandType.HighStraight, result);
        }
    }
}