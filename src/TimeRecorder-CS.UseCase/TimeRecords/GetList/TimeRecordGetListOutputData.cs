using System.Collections.Generic;
using System.Linq;
using TimeRecorder_CS.Domain.Models.TimeRecords;

namespace TimeRecorder_CS.UseCase.TimeRecords.GetList
{
    public sealed class TimeRecordGetListOutputData
    {
        private readonly List<TimeRecordGetListOutputItem> _timeRecordDTOs;

        public TimeRecordGetListOutputData(TimeCard timeCard)
        {
            _timeRecordDTOs = timeCard.List().Select(x =>
                {
                    var dto = x.ToDTO();
                    return new TimeRecordGetListOutputItem(
                        timeRecordId: dto.TimeRecordId,
                        accountId: dto.AccountId,
                        timeRecordTypeId: dto.TimeRecordTypeId,
                        timeRecordTypeName: dto.TimeRecordTypeName,
                        recordedDateTime: dto.RecordedDateTime
                        );
                }).ToList();
        }

        public List<TimeRecordGetListOutputItem> List => _timeRecordDTOs;
    }
}