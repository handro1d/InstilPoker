using System.ComponentModel;

namespace Instil.Poker.Domain.Enums
{
    public enum CardValue
    {
        [Description("2")]
        Two = 2,

        [Description("3")]
        Three = 3,

        [Description("4")]
        Four = 4,

        [Description("5")]
        Five = 5,

        [Description("6")]
        Six = 6,

        [Description("7")]
        Seven = 7,

        [Description("8")]
        Eight = 8,

        [Description("9")]
        Nine = 9,

        [Description("T")]
        Ten = 10,

        [Description("J")]
        Jack = 11,

        [Description("Q")]
        Queen = 12,

        [Description("K")]
        King = 13,

        [Description("A")]
        Ace = 0
    }
}