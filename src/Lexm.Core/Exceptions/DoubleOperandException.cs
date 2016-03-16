using System;
using System.Runtime.Serialization;

namespace Lexm.Core.Exceptions
{
    public class DoubleOperandException : Exception
    {
        public DoubleOperandException()
        {
        }

        public DoubleOperandException(string message) : base(message)
        {
        }

        public DoubleOperandException(string message, Exception innerException) : base(message, innerException)
        {
        }

        protected DoubleOperandException(SerializationInfo info, StreamingContext context) : base(info, context)
        {
        }
    }
}
