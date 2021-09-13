using TimeRecorder_CS.Domain.Models.Accounts;
using TimeRecorder_CS.Domain.Models.TimeRecords;
using TimeRecorder_CS.Domain.Types.TimeRecorders;

namespace TimeRecorder_CS.Domain.Services.TimeRecorders
{
    public sealed class TimeRecorder
    {
        private readonly ITimeRecordRepository _repository;

        public TimeRecorder(ITimeRecordRepository repository)
        {
            _repository = repository;
        }

        public TimeRecord StampStarting(AccountId accountId)
        {
            var stamped = TimeRecord.Create(accountId: accountId, timeRecordType: TimeRecordType.出勤);

            var latest = _repository.FindLatest(accountId);

            if (latest == null)
            {
                return stamped;
            }

            if (!latest.Is(TimeRecordType.退勤))
            {
                throw new TimeRecordCannotStampStartingException();
            }

            if (stamped.Before(latest))
            {
                throw new TimeRecordCannotStampStartingException();
            }

            return stamped;
        }

        public TimeRecord StampStopping(AccountId accountId)
        {
            var stamped = TimeRecord.Create(accountId: accountId, timeRecordType: TimeRecordType.退勤);

            var latest = _repository.FindLatest(accountId);
            if (latest == null || latest.Is(TimeRecordType.退勤))
            {
                throw new TimeRecordCannotStampStoppingException();
            }

            if (stamped.Before(latest))
            {
                throw new TimeRecordCannotStampStoppingException();
            }

            return stamped;
        }
    }
}
