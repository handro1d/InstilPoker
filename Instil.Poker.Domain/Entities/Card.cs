using Instil.Poker.Domain.Enums;
using System;

namespace Instil.Poker.Domain.Entities
{
    public sealed class Card
    {
        public CardSuit Suit { get; }
        public CardValue Value { get; }

        public Card(CardValue value, CardSuit suit)
        {
            Suit = suit;
            Value = value;
        }
        public override bool Equals(object obj)
        {
            if ((obj == null) || GetType().Equals(obj.GetType()))
            {
                return false;
            }
            
            var comparableObject = (Card)obj;
            return Suit == comparableObject.Suit && Value == comparableObject.Value;
        }

        public override int GetHashCode()
        {
            return Tuple.Create(Value, Suit).GetHashCode();
        }
    }
}