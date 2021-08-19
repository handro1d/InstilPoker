using System.Collections.Generic;
using Instil.Poker.Core;
using Instil.Poker.Core.Enums;
using Instil.Poker.Core.Tests.Fakes;
using Instil.Poker.Domain.Entities;
using Instil.Poker.Domain.Enums;
using NUnit.Framework;

namespace Instil.Poker.Core.Tests
{
    [TestFixture]
    internal sealed class PokerFaceFixture
    {
        private PokerFace _determination;

        [SetUp]
        public void SetUp()
        {
            _determination = new PokerFace();
        }

        [Test]
        public void DetermineHand_ShouldIdentifyRoyalFlush()
        {
            var cards = new List<Card>
            {
                new Card(CardValue.Ten, CardSuit.Clubs),
                new Card(CardValue.Ace, CardSuit.Clubs),
                new Card(CardValue.Queen, CardSuit.Clubs),
                new Card(CardValue.King, CardSuit.Clubs),
                new Card(CardValue.Jack, CardSuit.Clubs)
            };

            AssertDeterminedHand(cards, PokerHandType.RoyalFlush);
        }

        [Test]
        public void DetermineHand_ShouldIdentifyStraightFlush()
        {
            var cards = new List<Card>
            {
                new Card(CardValue.Two, CardSuit.Clubs),
                new Card(CardValue.Six, CardSuit.Clubs),
                new Card(CardValue.Four, CardSuit.Clubs),
                new Card(CardValue.Five, CardSuit.Clubs),
                new Card(CardValue.Three, CardSuit.Clubs)
            };

            AssertDeterminedHand(cards, PokerHandType.StraightFlush);
        }

        [Test]
        public void DetermineHand_ShouldIdentifyFourOfAKind()
        {
            var cards = new List<Card>
            {
                new Card(CardValue.Two, CardSuit.Hearts),
                new Card(CardValue.Two, CardSuit.Clubs),
                new Card(CardValue.Two, CardSuit.Diamonds),
                new Card(CardValue.Two, CardSuit.Spades),
                new Card(CardValue.Eight, CardSuit.Clubs)
            };

            AssertDeterminedHand(cards, PokerHandType.FourOfAKind);
        }

        [Test]
        public void DetermineHand_ShouldIdentifyFullHouse()
        {
            var cards = new List<Card>
            {
                new Card(CardValue.Six, CardSuit.Spades),
                new Card(CardValue.Six, CardSuit.Diamonds),
                new Card(CardValue.Six, CardSuit.Hearts),
                new Card(CardValue.King, CardSuit.Clubs),
                new Card(CardValue.King, CardSuit.Diamonds)
            };

            AssertDeterminedHand(cards, PokerHandType.FullHouse);
        }

        [Test]
        public void DetermineHand_ShouldIdentifyFlush()
        {
            var cards = new List<Card>
            {
                new Card(CardValue.Two, CardSuit.Hearts),
                new Card(CardValue.Four, CardSuit.Hearts),
                new Card(CardValue.Six, CardSuit.Hearts),
                new Card(CardValue.Eight, CardSuit.Hearts),
                new Card(CardValue.Jack, CardSuit.Hearts)
            };

            AssertDeterminedHand(cards, PokerHandType.Flush);
        }

        [Test]
        public void DetermineHand_ShouldIdentifyStraight()
        {
            var cards = new List<Card>
            {
                new Card(CardValue.Two, CardSuit.Clubs),
                new Card(CardValue.Six, CardSuit.Diamonds),
                new Card(CardValue.Four, CardSuit.Clubs),
                new Card(CardValue.Five, CardSuit.Spades),
                new Card(CardValue.Three, CardSuit.Clubs)
            };

            AssertDeterminedHand(cards, PokerHandType.Straight);
        }

        [Test]
        public void DetermineHand_ShouldIdentifyThreeOfAKind()
        {
            var cards = new List<Card>
            {
                new Card(CardValue.Two, CardSuit.Clubs),
                new Card(CardValue.Two, CardSuit.Spades),
                new Card(CardValue.Two, CardSuit.Hearts),
                new Card(CardValue.Six, CardSuit.Diamonds),
                new Card(CardValue.Nine, CardSuit.Clubs)
            };

            AssertDeterminedHand(cards, PokerHandType.ThreeOfAKind);
        }

        [Test]
        public void DetermineHand_ShouldIdentifyTwoPair()
        {
            var cards = new List<Card>
            {
                new Card(CardValue.Two, CardSuit.Clubs),
                new Card(CardValue.Two, CardSuit.Spades),
                new Card(CardValue.Five, CardSuit.Diamonds),
                new Card(CardValue.Five, CardSuit.Clubs),
                new Card(CardValue.Six, CardSuit.Diamonds)
            };

            AssertDeterminedHand(cards, PokerHandType.TwoPair);
        }

        [Test]
        public void DetermineHand_ShouldIdentifyOnePair()
        {
            var cards = new List<Card>
            {
                new Card(CardValue.Two, CardSuit.Clubs),
                new Card(CardValue.Two, CardSuit.Spades),
                new Card(CardValue.Four, CardSuit.Diamonds),
                new Card(CardValue.Nine, CardSuit.Spades),
                new Card(CardValue.Queen, CardSuit.Clubs)
            };

            AssertDeterminedHand(cards, PokerHandType.OnePair);
        }

        private void AssertDeterminedHand(IEnumerable<Card> cards, PokerHandType expectedHandType)
        {
            var hand = new FakePokerHand().WithCards(cards);

            var result = _determination.DetermineHand(hand.Object);

            Assert.AreEqual(expectedHandType, result);
        }
    }
}