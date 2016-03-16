using System;
using System.Runtime.Serialization;

namespace Lexm.Core.Exceptions
{
    public class BracketCountException : Exception
    {
        public BracketCountException()
        {
        }

        public BracketCountException(string message) : base(message)
        {
        }

        public BracketCountException(string message, Exception innerException) : base(message, innerException)
        {
        }

        protected BracketCountException(SerializationInfo info, StreamingContext context) : base(info, context)
        {
        }
    }
}
