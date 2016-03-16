using System;
using System.Runtime.Serialization;

namespace Lexm.Core.Exceptions
{
    public class FirstOperandException : Exception
    {
        public FirstOperandException()
        {
        }

        public FirstOperandException(string message) : base(message)
        {
        }

        public FirstOperandException(string message, Exception innerException) : base(message, innerException)
        {
        }

        protected FirstOperandException(SerializationInfo info, StreamingContext context) : base(info, context)
        {
        }
    }
}
