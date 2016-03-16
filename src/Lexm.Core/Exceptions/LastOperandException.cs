using System;
using System.Runtime.Serialization;

namespace Lexm.Core.Exceptions
{
    public class LastOperandException : Exception
    {
        public LastOperandException()
        {
        }

        public LastOperandException(string message) : base(message)
        {
        }

        public LastOperandException(string message, Exception innerException) : base(message, innerException)
        {
        }

        protected LastOperandException(SerializationInfo info, StreamingContext context) : base(info, context)
        {
        }
    }
}
