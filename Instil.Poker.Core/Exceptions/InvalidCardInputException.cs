using System;
using System.Runtime.Serialization;

namespace Instil.Poker.Core.Exceptions
{
    [System.Serializable]
    public class InvalidCardInputException : Exception
    {
        public InvalidCardInputException(string invalidInput)
            : base($"Invalid Card input detected: {invalidInput}") { }

        protected InvalidCardInputException(SerializationInfo info, StreamingContext context) 
            : base(info, context) { }
    }
}