using System;

namespace TimeRecorder_CS.Domain.Models.TimeRecords
{
    public sealed class TimeRecordId
    {
        private readonly string _value;

        private TimeRecordId(string value)
        {
            _value = value;
        }

        public static TimeRecordId From(string value)
        {
            return new TimeRecordId(value);
        }

        public static TimeRecordId Create()
        {
            return new TimeRecordId(Ulid.NewUlid().ToString());
        }

        public override string ToString()
        {
            return _value;
        }

        internal string Value => _value;
    }
}