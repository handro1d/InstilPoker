using System;

namespace Instil.Poker.Core.Exceptions
{

    [Serializable]
    public class InvalidHandException : Exception
    {
        public InvalidHandException(string message)
            : base(message) { }

        protected InvalidHandException(
            System.Runtime.Serialization.SerializationInfo info,
            System.Runtime.Serialization.StreamingContext context)
            : base(info, context) { }
    }
}
