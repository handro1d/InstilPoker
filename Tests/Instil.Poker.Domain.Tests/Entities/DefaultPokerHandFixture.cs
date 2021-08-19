using System.Collections.Generic;
using System.Linq;
using Instil.Poker.Domain.Entities;
using Instil.Poker.Domain.Enums;
using Instil.Poker.Domain.Exceptions;
using Instil.Poker.Tests.Common;
using NUnit.Framework;

namespace Instil.Poker.Domain.Tests.Entities
{
    [TestFixture]
    internal sealed class DefaultPokerHandFixture
    {
        [Test]
        public void Validate_ShouldValidateANullHand()
        {
            var hand = new DefaultPokerHand(null);

            var validationException = Assert.Throws<ValidationException>(() =>
            {
                hand.Validate();
            });

            var expectedError = "Hand must contain some cards.";

            CollectionAssert.AreEquivalent(new List<string> { expectedError }, validationException.ValidationMessages);
        }

        [Test]
        public void Validate_ShouldValidateAnEmptyHand()
        {
            var cards = new List<Card>();
            var hand = new DefaultPokerHand(cards);

            var validationException = Assert.Throws<ValidationException>(() =>
            {
                hand.Validate();
            });

            var expectedError = "Hand must contain some cards.";

            CollectionAssert.AreEquivalent(new List<string> { expectedError }, validationException.ValidationMessages);
        }

        [Test]
        public void Validate_ShouldValidateTooManyCards()
        {
            var cards = CardUtility.GenerateRandomCards(6);
            var hand = new DefaultPokerHand(cards);

            var validationException = Assert.Throws<ValidationException>(() =>
            {
                hand.Validate();
            });

            var expectedError = "Hand can only contain a maximum of 5 Cards.";

            CollectionAssert.AreEquivalent(new List<string> { expectedError }, validationException.ValidationMessages);
        }
    }
}