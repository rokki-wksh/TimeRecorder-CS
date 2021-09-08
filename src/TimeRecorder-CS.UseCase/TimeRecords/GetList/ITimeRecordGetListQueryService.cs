using System;
using TimeRecorder_CS.Domain.Models.Accounts;
using TimeRecorder_CS.Domain.Models.TimeRecords;

namespace TimeRecorder_CS.UseCase.TimeRecords.GetList
{
    public interface ITimeRecordGetListQueryService
    {
        TimeCard Query(AccountId accountId, DateTime from, DateTime to);
    }
}