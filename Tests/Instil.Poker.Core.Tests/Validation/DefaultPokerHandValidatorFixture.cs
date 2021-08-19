using Instil.Poker.Core.Tests.Fakes;
using Instil.Poker.Core.Validation;
using Instil.Poker.Domain.Entities;
using Instil.Poker.Tests.Common;
using NUnit.Framework;
using System.Collections.Generic;

namespace Instil.Poker.Core.Tests.Validation
{
    [TestFixture]
    internal sealed class DefaultPokerHandValidatorFixture
    {
        private DefaultPokerHandValidator _validator;

        [SetUp]
        public void SetUp()
        {
            _validator = new DefaultPokerHandValidator();
        }

        [Test]
        public void Validate_ShouldValidateANullHand()
        {
            var hand = new FakePokerHand().WithCards(null);

            var result = _validator.Validate(hand.Object);

            var expectedError = "Hand must contain some cards.";

            Assert.IsFalse(result.Succeeded);
            Assert.AreEqual(expectedError, result.Error);
        }

        [Test]
        public void Validate_ShouldValidateAnEmptyHand()
        {
            var hand = new FakePokerHand().WithCards(new List<Card>());

            var result = _validator.Validate(hand.Object);

            var expectedError = "Hand must contain some cards.";

            Assert.IsFalse(result.Succeeded);
            Assert.AreEqual(expectedError, result.Error);
        }

        [Test]
        public void Validate_ShouldValidateTooManyCards()
        {
            var cards = CardUtility.GenerateRandomCards(6);
            var hand = new FakePokerHand().WithCards(cards);

            var result = _validator.Validate(hand.Object);

            var expectedError = "Hand can only contain a maximum of 5 Cards.";

            Assert.IsFalse(result.Succeeded);
            Assert.AreEqual(expectedError, result.Error);
        }

        [Test]
        public void Validate_ShouldValidateHand()
        {
            var cards = CardUtility.GenerateRandomCards(5);
            var hand = new FakePokerHand().WithCards(cards);

            var result = _validator.Validate(hand.Object);

            Assert.IsTrue(result.Succeeded);
        }
    }
}
