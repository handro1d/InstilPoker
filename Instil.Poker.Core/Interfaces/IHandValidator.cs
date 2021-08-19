using Instil.Poker.Core.Validation;
using Instil.Poker.Domain.Interfaces;

namespace Instil.Poker.Core.Interfaces
{
    public interface IHandValidator
    {
        /// <summary>
        /// Validate poker hand.
        /// </summary>
        /// <param name="pokerHand">Poker hand to validate</param>
        /// <returns><see cref="Instil.Poker.Core.Validation.ValidationResult"> indicating validity of provided poker hand.</returns>
        ValidationResult Validate(IPokerHand pokerHand);
    }
}
