using TimeRecorder_CS.Domain.Models.Accounts;
using TimeRecorder_CS.Domain.Models.TimeRecords;
using TimeRecorder_CS.Domain.Types.DateRanges;

namespace TimeRecorder_CS.UseCase.TimeRecords.GetList
{
    public interface ITimeRecordGetListQueryService
    {
        TimeCard Query(AccountId accountId, DateRange dateRange);
    }
}