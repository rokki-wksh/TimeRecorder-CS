using System;

namespace TimeRecorder_CS.Domain.Models.TimeRecords
{
    public sealed class RecordedDateTime
    {
        private readonly DateTime _value;

        private RecordedDateTime(DateTime value)
        {
            _value = value;
        }

        public static RecordedDateTime From(DateTime value)
        {
            return new RecordedDateTime(value);
        }

        public static RecordedDateTime Create()
        {
            return new RecordedDateTime(DateTime.Now);
        }

        public bool Before(RecordedDateTime other)
        {
            return _value < other._value;
        }

        internal DateTime Value => _value;
    }
}