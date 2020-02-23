using System;
using System.Runtime.Serialization;

namespace ClassLibrary1.Facade
{
    [Serializable]
    internal class TicketsSoldOutException : Exception
    {
        public TicketsSoldOutException()
        {
        }

        public TicketsSoldOutException(string message) : base(message)
        {
        }

        public TicketsSoldOutException(string message, Exception innerException) : base(message, innerException)
        {
        }

        protected TicketsSoldOutException(SerializationInfo info, StreamingContext context) : base(info, context)
        {
        }
    }
}