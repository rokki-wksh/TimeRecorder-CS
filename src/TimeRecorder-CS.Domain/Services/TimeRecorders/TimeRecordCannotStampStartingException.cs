using System;
using System.Runtime.Serialization;
using TimeRecorder_CS.Domain.Models.TimeRecords;

namespace TimeRecorder_CS.Domain.Types.TimeRecorders
{
    [Serializable]
    public class TimeRecordCannotStampStartingException : Exception
    {
        public TimeRecordCannotStampStartingException() : base($"{TimeRecordType.出勤.Name}を打刻できません。") { }
        public TimeRecordCannotStampStartingException(string message) : base(message) { }
        public TimeRecordCannotStampStartingException(string message, Exception innerException) : base(message, innerException) { }

        protected TimeRecordCannotStampStartingException(SerializationInfo info, StreamingContext context) : base(info, context) { }
    }
}
