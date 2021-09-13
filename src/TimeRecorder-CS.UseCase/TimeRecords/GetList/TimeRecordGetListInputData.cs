using System;
using TimeRecorder_CS.Domain.Models.Accounts;
using TimeRecorder_CS.Domain.Types.DateRanges;

namespace TimeRecorder_CS.UseCase.TimeRecords.GetList
{
    public sealed class TimeRecordGetListInputData
    {
        private readonly AccountId _accountId;
        private readonly DateRange _dateRange;

        public TimeRecordGetListInputData(string accountId, DateTime? from, DateTime? to)
        {
            _accountId = AccountId.From(accountId);
            _dateRange = new DateRange(from, to);
        }

        internal AccountId AccountId => _accountId;
        internal DateRange DateRange => _dateRange;
    }
}