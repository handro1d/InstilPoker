using Instil.Poker.Core.Interfaces;
using Instil.Poker.Domain.Interfaces;
using System.Linq;

namespace Instil.Poker.Core.Validation
{
    public sealed class DefaultPokerHandValidator : IHandValidator
    {
        private const int MaxNumberOfCards = 5;

        public ValidationResult Validate(IPokerHand pokerHand)
        {
            if (pokerHand.Cards == null || !pokerHand.Cards.Any())
            {
                return ValidationResult.Failed("Hand must contain some cards.");
            }

            if (pokerHand.Cards.Count() > MaxNumberOfCards)
            {
                return ValidationResult.Failed($"Hand can only contain a maximum of {MaxNumberOfCards} Cards.");
            }

            return ValidationResult.Success();
        }
    }
}