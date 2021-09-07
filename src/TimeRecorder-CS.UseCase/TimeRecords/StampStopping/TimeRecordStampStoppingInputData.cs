using TimeRecorder_CS.Domain.Models.Accounts;

namespace TimeRecorder_CS.UseCase.TimeRecords.StampStopping
{
    public sealed class TimeRecordStampStoppingInputData
    {
        private readonly AccountId _accountId;

        public TimeRecordStampStoppingInputData(string accountId)
        {
            _accountId = AccountId.From(accountId);
        }

        internal AccountId AccountId => _accountId;
    }
}
