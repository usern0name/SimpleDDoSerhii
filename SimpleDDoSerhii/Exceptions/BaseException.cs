using System;
using System.Runtime.Serialization;

namespace SimpleDDoSerhii.Exceptions
{
    [Serializable]
    public class BaseException: Exception
    {
        private object _value;
        public BaseException() { }
        public BaseException(string message) : base(message) { }
        public BaseException(string message, Exception inner) : base(message, inner) { }
        protected BaseException(SerializationInfo info, StreamingContext context) : base(info, context) { }
        public BaseException(string message, object value) : base(message)
        {
            _value = value;
        }
        public object Value
        {
            get { return _value; }
        }
    }
}
