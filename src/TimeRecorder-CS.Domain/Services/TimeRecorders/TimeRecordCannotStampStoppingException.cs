using System;
using System.Runtime.Serialization;
using TimeRecorder_CS.Domain.Models.TimeRecords;

namespace TimeRecorder_CS.Domain.Types.TimeRecorders
{
    [Serializable]
    public class TimeRecordCannotStampStoppingException : Exception
    {
        public TimeRecordCannotStampStoppingException() : base($"{TimeRecordType.退勤.Name}を打刻できません。") { }
        public TimeRecordCannotStampStoppingException(string message) : base(message) { }
        public TimeRecordCannotStampStoppingException(string message, Exception innerException) : base(message, innerException) { }

        protected TimeRecordCannotStampStoppingException(SerializationInfo info, StreamingContext context) : base(info, context) { }
    }
}
