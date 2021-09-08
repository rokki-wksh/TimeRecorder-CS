using System.Collections.Generic;
using System.Linq;

namespace TimeRecorder_CS.Domain.Models.TimeRecords
{
    public sealed class TimeCard
    {
        private readonly List<TimeRecord> _timeRecords;

        private TimeCard(List<TimeRecord> timeRecords)
        {
            _timeRecords = timeRecords;
        }

        public static TimeCard From(List<TimeRecord> timeRecords)
        {
            return new(timeRecords);
        }

        public List<TimeRecord> List()
        {
            return _timeRecords.ToList();
        }
    }
}
