using TimeRecorder_CS.Domain.Models.Accounts;

namespace TimeRecorder_CS.UseCase.TimeRecords.StampStarting
{
    public sealed class TimeRecordStampStartingInputData
    {
        private readonly AccountId _accountId;

        public TimeRecordStampStartingInputData(string accountId)
        {
            _accountId = AccountId.From(accountId);
        }

        internal AccountId AccountId => _accountId;
    }
}
