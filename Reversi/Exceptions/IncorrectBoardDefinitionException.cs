using System;
using System.Runtime.Serialization;

namespace Reversi
{
    public class IncorrectBoardDefinitionException : Exception
    {
        public IncorrectBoardDefinitionException()
        {
        }

        public IncorrectBoardDefinitionException(string message) : base(message)
        {
        }

        public IncorrectBoardDefinitionException(string message, Exception innerException) : base(message, innerException)
        {
        }

        protected IncorrectBoardDefinitionException(SerializationInfo info, StreamingContext context) : base(info, context)
        {
        }
    }
}