using Instil.Poker.Core.Enums;
using Instil.Poker.Domain.Interfaces;

namespace Instil.Poker.Core.Interfaces
{
    public interface IPokerHandAssessor
    {
        /// <summary>
        /// Set subsequent assessor.
        /// </summary>
        /// <param name="handler">Subsequent assessor.</param>
        /// <returns>Subsequent assessor.</returns>
        IPokerHandAssessor SetNext(IPokerHandAssessor handler);

        /// <summary>
        /// Assess poker hand to determine what hand (if any) is held.
        /// </summary>
        /// <param name="hand">Poker hand to assess</param>
        /// <returns><see cref="Instil.Poker.Core.Enums.PokerHandType"> indicating determined hand type.</returns>
        PokerHandType Assess(IPokerHand hand);
    }
}