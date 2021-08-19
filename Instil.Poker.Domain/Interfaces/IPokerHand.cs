using System.Collections.Generic;
using Instil.Poker.Domain.Entities;

namespace Instil.Poker.Domain.Interfaces
{
    public interface IPokerHand
    {
        IEnumerable<Card> Cards { get; }

        int MaxNumberOfCards { get; }

        void Validate();
    }
}