using System;

namespace TimeRecorder_CS.Domain.Types.DateRanges
{
    public sealed class DateRange
    {
        private readonly DateTime? _from;
        private readonly DateTime? _to;

        public DateRange(DateTime? from, DateTime? to)
        {
            var f = from?.Date;
            var t = to?.Date;

            if (f.HasValue && t.HasValue)
            {
                if (f > t) { throw new InvalidDateRangeException(); }
            }

            _from = f;
            _to = t;
        }

        public bool Contains(DateTime datetime)
        {
            var date = datetime.Date;

            // 無期限
            if (!_from.HasValue && !_to.HasValue)
            {
                return true;
            }

            // from ～ date ～ 無期限
            if (_from.HasValue && !_to.HasValue && _from <= date)
            {
                return true;
            }

            // 無期限 ～ date ～ to
            if (!_from.HasValue && _to.HasValue && date <= _to)
            {
                return true;
            }

            // from ～ date ～ to
            if (_from.HasValue && _to.HasValue && _from <= date && date <= _to)
            {
                return true;
            }

            return false;
        }

        public DateTime? From => _from;
        public DateTime? To => _to;
    }
}
