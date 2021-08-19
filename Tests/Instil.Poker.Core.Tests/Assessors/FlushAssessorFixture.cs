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
    internal sealed class FlushAssessorFixture
    {
        private FlushAssessor _assessor;

        [SetUp]
        public void SetUp()
        {
            _assessor = new FlushAssessor();
        }

        [Test]
        public void Assess_ShouldReturnNoneForHandOfMultipleSuits()
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

            Assert.AreEqual(PokerHandType.None, result);
        }

        [Test]
        public void Assess_ShouldReturnNoneForSequentialCards()
        {
            var cards = new List<Card>
            {
                new Card(CardValue.Two, CardSuit.Hearts),
                new Card(CardValue.Four, CardSuit.Hearts),
                new Card(CardValue.Three, CardSuit.Hearts),
                new Card(CardValue.Six, CardSuit.Hearts),
                new Card(CardValue.Five, CardSuit.Hearts)
            };

            var hand = new FakePokerHand().WithCards(cards);

            var result = _assessor.Assess(hand.Object);

            Assert.AreEqual(PokerHandType.None, result);
        }

        [Test]
        public void Assess_ShouldReturnNoneForLowAceSequentialCards()
        {
            var cards = new List<Card>
            {
                new Card(CardValue.Two, CardSuit.Hearts),
                new Card(CardValue.Four, CardSuit.Hearts),
                new Card(CardValue.Three, CardSuit.Hearts),
                new Card(CardValue.Ace, CardSuit.Hearts),
                new Card(CardValue.Five, CardSuit.Hearts)
            };

            var hand = new FakePokerHand().WithCards(cards);

            var result = _assessor.Assess(hand.Object);

            Assert.AreEqual(PokerHandType.None, result);
        }

        [Test]
        public void Assess_ShouldReturnNoneForLowHighSequentialCards()
        {
            var cards = new List<Card>
            {
                new Card(CardValue.Ten, CardSuit.Hearts),
                new Card(CardValue.Queen, CardSuit.Hearts),
                new Card(CardValue.Jack, CardSuit.Hearts),
                new Card(CardValue.Ace, CardSuit.Hearts),
                new Card(CardValue.King, CardSuit.Hearts)
            };

            var hand = new FakePokerHand().WithCards(cards);

            var result = _assessor.Assess(hand.Object);

            Assert.AreEqual(PokerHandType.None, result);
        }

        [Test]
        public void Assess_ShouldIdentifyFlush()
        {
            var cards = new List<Card>
            {
                new Card(CardValue.Two, CardSuit.Hearts),
                new Card(CardValue.Four, CardSuit.Hearts),
                new Card(CardValue.Six, CardSuit.Hearts),
                new Card(CardValue.Eight, CardSuit.Hearts),
                new Card(CardValue.Jack, CardSuit.Hearts)
            };

            var hand = new FakePokerHand().WithCards(cards);

            var result = _assessor.Assess(hand.Object);

            Assert.AreEqual(PokerHandType.Flush, result);
        }

        [Test]
        public void Assess_ShouldIdentifyFlushWithAce()
        {
            var cards = new List<Card>
            {
                new Card(CardValue.Two, CardSuit.Hearts),
                new Card(CardValue.Four, CardSuit.Hearts),
                new Card(CardValue.Six, CardSuit.Hearts),
                new Card(CardValue.Ace, CardSuit.Hearts),
                new Card(CardValue.Jack, CardSuit.Hearts)
            };

            var hand = new FakePokerHand().WithCards(cards);

            var result = _assessor.Assess(hand.Object);

            Assert.AreEqual(PokerHandType.Flush, result);
        }
    }
}