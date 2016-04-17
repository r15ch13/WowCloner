/*
 * Licensed under the MIT License (http://r15ch13.mit-license.org/)
 */
using System;
using System.Runtime.Serialization;

namespace WowCloner
{
    [Serializable]
    public class MyException : Exception
    {
        public MyException() : base() { }
        public MyException(string message) : base(message) { }
        public MyException(string message, Exception innerException) : base(message, innerException) { }
        protected MyException(SerializationInfo info, StreamingContext context) : base(info, context) { }
    }
}
