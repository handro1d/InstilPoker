using System.Collections.Generic;

namespace Instil.Poker.Domain.Exceptions
{
    [System.Serializable]
    public class ValidationException : System.Exception
    {
        public IEnumerable<string> ValidationMessages { get; }

        public ValidationException(IEnumerable<string> validationMessages)
            : base("Entity was invalid")
        {
            ValidationMessages = validationMessages;
        }

        protected ValidationException(
            System.Runtime.Serialization.SerializationInfo info,
            System.Runtime.Serialization.StreamingContext context) : base(info, context) { }
    }
}