using System.Collections.Generic;
using System.Linq;
using TimeRecorder_CS.Domain.Models.Accounts;
using TimeRecorder_CS.Domain.Models.TimeRecords;

namespace TimeRecorder_CS.Persister.InMemory.Repositories.TimeRecords
{
    public sealed class TimeRecordRepository : ITimeRecordRepository
    {
        private readonly Dictionary<string, TimeRecordDTO> _store = new();

        public void Delete(TimeRecordId timeRecordId)
        {
            _store.Remove(timeRecordId.ToString());
        }

        public TimeRecord Find(TimeRecordId timeRecordId)
        {
            _store.TryGetValue(timeRecordId.ToString(), out var dto);

            if (dto == null)
            {
                return null;
            }

            return TimeRecord.From(
                timeRecordId: dto.TimeRecordId,
                accountId: dto.AccountId,
                timeRecordType: dto.TimeRecordTypeId,
                recordedDateTime: dto.RecordedDateTime
                );
        }

        public TimeRecord FindLatest(AccountId accountId)
        {
            var dto = _store
                .Where(item => item.Value.AccountId == accountId.ToString())
                .OrderByDescending(item => item.Value.RecordedDateTime)
                .Select(item => item.Value)
                .FirstOrDefault();

            if (dto == null)
            {
                return null;
            }

            return TimeRecord.From(
                timeRecordId: dto.TimeRecordId,
                accountId: dto.AccountId,
                timeRecordType: dto.TimeRecordTypeId,
                recordedDateTime: dto.RecordedDateTime
                );
        }

        public void Save(TimeRecord timeRecord)
        {
            _store[timeRecord.TimeRecordId.ToString()] = timeRecord.ToDTO();
        }

        internal List<TimeRecordDTO> List()
        {
            return _store.Select(x => x.Value).ToList();
        }
    }
}
