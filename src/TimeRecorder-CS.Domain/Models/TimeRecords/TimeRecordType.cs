using System.Linq;
using System.Reflection;

namespace TimeRecorder_CS.Domain.Models.TimeRecords
{
    public sealed class TimeRecordType
    {
        private readonly byte _id;
        private readonly string _name;

        public static readonly TimeRecordType 出勤 = new(0, "出勤");
        public static readonly TimeRecordType 退勤 = new(1, "退勤");

        private TimeRecordType(byte id, string name)
        {
            _id = id;
            _name = name;
        }

        public bool Is(TimeRecordType other)
        {
            return _id == other._id;
        }

        public static TimeRecordType From(byte value)
        {
            var fields = typeof(TimeRecordType).GetFields(BindingFlags.Public | BindingFlags.Static | BindingFlags.DeclaredOnly);
            var items = fields.Select(f => f.GetValue(null)).Cast<TimeRecordType>();

            return items.FirstOrDefault(item => item._id == value);
        }

        public byte Id => _id;
        public string Name => _name;
    }
}
