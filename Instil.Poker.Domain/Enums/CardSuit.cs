using System.ComponentModel;

namespace Instil.Poker.Domain.Enums
{
    public enum CardSuit
    {
        [Description("C")]
        Clubs,

        [Description("D")]
        Diamonds,

        [Description("H")]
        Hearts,

        [Description("S")]
        Spades
    }
}