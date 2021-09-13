using System.Linq;
using TimeRecorder_CS.Domain.Models.Accounts;
using TimeRecorder_CS.Domain.Models.TimeRecords;
using TimeRecorder_CS.Domain.Types.DateRanges;
using TimeRecorder_CS.Persister.InMemory.Repositories.TimeRecords;
using TimeRecorder_CS.UseCase.TimeRecords.GetList;

namespace TimeRecorder_CS.Persister.InMemory.QueryServices.TimeRecordGetList
{
    public sealed class TimeRecordGetListQueryService : ITimeRecordGetListQueryService
    {
        // InMemoryでも一連の操作を可能にするためrepositoryを見る。
        private readonly TimeRecordRepository _repository;

        public TimeRecordGetListQueryService(TimeRecordRepository repository)
        {
            _repository = repository;
        }

        public TimeCard Query(AccountId accountId, DateRange dateRange)
        {
            var list = _repository.List()
                .Where(x => x.AccountId == accountId.ToString())
                .Where(x => dateRange.Contains(x.RecordedDateTime))
                .Select(dto =>
                {
                    return TimeRecord.From(
                        timeRecordId: dto.TimeRecordId,
                        accountId: dto.AccountId,
                        timeRecordType: dto.TimeRecordTypeId,
                        recordedDateTime: dto.RecordedDateTime
                        );
                }).ToList();

            return TimeCard.From(list);
        }
    }
}
