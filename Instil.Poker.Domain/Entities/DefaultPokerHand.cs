using System;
using System.Collections.Generic;
using System.Linq;
using Instil.Poker.Domain.Enums;
using Instil.Poker.Domain.Exceptions;
using Instil.Poker.Domain.Interfaces;

namespace Instil.Poker.Domain.Entities
{
    public class DefaultPokerHand : IPokerHand
    {
        public IEnumerable<Card> Cards { get; }

        public virtual int MaxNumberOfCards => 5;

        public DefaultPokerHand(IEnumerable<Card> cards)
        {
            Cards = cards;
        }

        public virtual void Validate()
        {
            var failedValidation = new List<string>();

            if (Cards == null || !Cards.Any())
            {
                failedValidation.Add("Hand must contain some cards.");
            }
            else if (Cards.Count() > MaxNumberOfCards)
            {
                failedValidation.Add($"Hand can only contain a maximum of {MaxNumberOfCards} Cards.");
            }

            if (failedValidation.Any())
            {
                throw new ValidationException(failedValidation);
            }
        }
    }
}