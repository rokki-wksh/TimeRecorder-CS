using System;
using TimeRecorder_CS.Domain.Models.Accounts;

namespace TimeRecorder_CS.UseCase.TimeRecords.GetList
{
    public sealed class TimeRecordGetListInputData
    {
        private readonly AccountId _accountId;
        private readonly DateTime _from;
        private readonly DateTime _to;

        public TimeRecordGetListInputData(string accountId, DateTime from, DateTime to)
        {
            _accountId = AccountId.From(accountId);
            _from = from;
            _to = to;
        }

        internal AccountId AccountId => _accountId;
        internal DateTime From => _from;
        internal DateTime To => _to;
    }
}