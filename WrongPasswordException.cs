using System;
using System.Runtime.Serialization;

namespace ClassLibrary1
{
    [Serializable]
    internal class WrongPasswordException : Exception
    {
        public WrongPasswordException()
        {
        }

        public WrongPasswordException(string message) : base(message)
        {
            Console.WriteLine("Wrong Password");
        }

        public WrongPasswordException(string message, Exception innerException) : base(message, innerException)
        {
        }

        protected WrongPasswordException(SerializationInfo info, StreamingContext context) : base(info, context)
        {
        }
    }
}