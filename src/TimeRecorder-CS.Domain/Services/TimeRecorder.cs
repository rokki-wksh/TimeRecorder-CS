using System;
using TimeRecorder_CS.Domain.Models.Accounts;
using TimeRecorder_CS.Domain.Models.TimeRecords;

namespace TimeRecorder_CS.Domain.Services
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
            if (latest != null && !latest.Is(TimeRecordType.退勤))
            {
                throw new Exception($"{TimeRecordType.出勤.Name}を打刻できません。");
            }

            if (stamped.Before(latest))
            {
                throw new Exception($"{TimeRecordType.出勤.Name}を打刻できません。");
            }

            return stamped;
        }

        public TimeRecord StampStopping(AccountId accountId)
        {
            var stamped = TimeRecord.Create(accountId: accountId, timeRecordType: TimeRecordType.退勤);

            var latest = _repository.FindLatest(accountId);
            if (latest == null || latest.Is(TimeRecordType.退勤))
            {
                throw new Exception($"{TimeRecordType.退勤.Name}を打刻できません。");
            }

            if (stamped.Before(latest))
            {
                throw new Exception($"{TimeRecordType.退勤.Name}を打刻できません。");
            }

            return stamped;
        }
    }
}
