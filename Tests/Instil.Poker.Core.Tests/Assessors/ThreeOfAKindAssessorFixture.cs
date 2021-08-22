using System.Collections.Generic;
using Instil.Poker.Core.Assessors;
using Instil.Poker.Core.Enums;
using Instil.Poker.Core.Tests.Fakes;
using Instil.Poker.Domain.Entities;
using Instil.Poker.Domain.Enums;
using NUnit.Framework;

namespace Instil.Poker.Core.Tests.Assessors
{
    [TestFixture]
    internal sealed class ThreeOfAKindAssessorFixture
    {
        private ThreeOfAKindAssessor _assessor;

        [SetUp]
        public void SetUp()
        {
            _assessor = new ThreeOfAKindAssessor();
        }

        [Test]
        public void Assess_ShouldReturnHighCardForNoDuplicatedRanks()
        {
            var cards = new List<Card>
            {
                new Card(CardValue.Two, CardSuit.Clubs),
                new Card(CardValue.Seven, CardSuit.Spades),
                new Card(CardValue.Nine, CardSuit.Spades),
                new Card(CardValue.Six, CardSuit.Diamonds),
                new Card(CardValue.Queen, CardSuit.Clubs)
            };

            var hand = new FakePokerHand().WithCards(cards);

            var result = _assessor.Assess(hand.Object);

            Assert.AreEqual(PokerHandType.HighCard, result);
        }

        [Test]
        public void Assess_ShouldReturnHighCardForMultipleDuplicatedRanks()
        {
            var cards = new List<Card>
            {
                new Card(CardValue.Two, CardSuit.Clubs),
                new Card(CardValue.Two, CardSuit.Spades),
                new Card(CardValue.Two, CardSuit.Hearts),
                new Card(CardValue.Six, CardSuit.Diamonds),
                new Card(CardValue.Six, CardSuit.Clubs)
            };

            var hand = new FakePokerHand().WithCards(cards);

            var result = _assessor.Assess(hand.Object);

            Assert.AreEqual(PokerHandType.HighCard, result);
        }

        [Test]
        public void Assess_ShouldIdentifyThreeOfAKind()
        {
            var cards = new List<Card>
            {
                new Card(CardValue.Two, CardSuit.Clubs),
                new Card(CardValue.Two, CardSuit.Spades),
                new Card(CardValue.Two, CardSuit.Hearts),
                new Card(CardValue.Six, CardSuit.Diamonds),
                new Card(CardValue.Nine, CardSuit.Clubs)
            };

            var hand = new FakePokerHand().WithCards(cards);

            var result = _assessor.Assess(hand.Object);

            Assert.AreEqual(PokerHandType.ThreeOfAKind, result);
        }
    }
}