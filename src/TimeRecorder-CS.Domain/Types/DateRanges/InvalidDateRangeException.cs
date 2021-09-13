using System;
using System.Runtime.Serialization;

namespace TimeRecorder_CS.Domain.Types.DateRanges
{
    [Serializable]
    public class InvalidDateRangeException : Exception
    {
        public InvalidDateRangeException() : base("不正な日付範囲です。") { }
        public InvalidDateRangeException(string message) : base(message) { }
        public InvalidDateRangeException(string message, Exception innerException) : base(message, innerException) { }

        protected InvalidDateRangeException(SerializationInfo info, StreamingContext context) : base(info, context) { }
    }
}
