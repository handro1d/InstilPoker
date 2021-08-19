using System;

namespace Instil.Poker.Core.Exceptions
{
    [System.Serializable]
    public class InvalidFileException : Exception
    {
        public InvalidFileException(string message)
            : base(message) { }

        protected InvalidFileException(
            System.Runtime.Serialization.SerializationInfo info,
            System.Runtime.Serialization.StreamingContext context)
            : base(info, context) { }
    }
}