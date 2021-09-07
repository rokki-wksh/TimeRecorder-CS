using TimeRecorder_CS.Domain.Models.Accounts;

namespace TimeRecorder_CS.Domain.Models.TimeRecords
{
    public interface ITimeRecordRepository
    {
        TimeRecord Find(TimeRecordId timeRecordId);
        TimeRecord FindLatest(AccountId accountId);
        void Save(TimeRecord timeRecord);
        void Delete(TimeRecordId timeRecordId);
    }
}
