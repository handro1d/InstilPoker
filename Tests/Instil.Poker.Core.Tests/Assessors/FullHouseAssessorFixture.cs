using Instil.Poker.Core.Assessors;
using Instil.Poker.Core.Enums;
using Instil.Poker.Core.Tests.Fakes;
using Instil.Poker.Domain.Entities;
using Instil.Poker.Domain.Enums;
using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Instil.Poker.Core.Tests.Assessors
{
    [TestFixture]
    internal sealed class FullHouseAssessorFixture
    {
        private FullHouseAssessor _assessor;

        [SetUp]
        public void SetUp()
        {
            _assessor = new FullHouseAssessor();
        }

        [Test]
        public void Assess_ShouldReturnHighCardForMultipleRanks()
        {
            var cards = new List<Card>
            {
                new Card(CardValue.Six, CardSuit.Spades),
                new Card(CardValue.Seven, CardSuit.Diamonds),
                new Card(CardValue.Six, CardSuit.Hearts),
                new Card(CardValue.King, CardSuit.Clubs),
                new Card(CardValue.Jack, CardSuit.Diamonds)
            };

            var hand = new FakePokerHand().WithCards(cards);

            var result = _assessor.Assess(hand.Object);

            Assert.AreEqual(PokerHandType.HighCard, result);
        }

        [Test]
        public void Assess_ShouldReturnHighCardForIncorrectCountWithinRanks()
        {
            var cards = new List<Card>
            {
                new Card(CardValue.Six, CardSuit.Spades),
                new Card(CardValue.Six, CardSuit.Diamonds),
                new Card(CardValue.Six, CardSuit.Hearts),
                new Card(CardValue.Six, CardSuit.Clubs),
                new Card(CardValue.King, CardSuit.Diamonds)
            };

            var hand = new FakePokerHand().WithCards(cards);

            var result = _assessor.Assess(hand.Object);

            Assert.AreEqual(PokerHandType.HighCard, result);
        }

        [Test]
        public void Assess_ShouldIdentifyFullHouse()
        {
            var cards = new List<Card>
            {
                new Card(CardValue.Six, CardSuit.Spades),
                new Card(CardValue.Six, CardSuit.Diamonds),
                new Card(CardValue.Six, CardSuit.Hearts),
                new Card(CardValue.King, CardSuit.Clubs),
                new Card(CardValue.King, CardSuit.Diamonds)
            };

            var hand = new FakePokerHand().WithCards(cards);

            var result = _assessor.Assess(hand.Object);

            Assert.AreEqual(PokerHandType.FullHouse, result);
        }
    }
}
