using System;
using TimeRecorder_CS.Domain.Models.Accounts;
using TimeRecorder_CS.Domain.Models.TimeRecords;

namespace TimeRecorder_CS.UseCase.Test.TimeRecords.StampStarting
{
    internal static class CreateTestDataExtension
    {
        private static readonly AccountId _accountId = AccountId.Create();

        internal static void CreateTestData(this ITimeRecordRepository repository)
        {
            var 出勤 = TimeRecord.Create(_accountId, TimeRecordType.出勤);
            repository.Save(出勤);
        }

        internal static AccountId TestAccountId(this ITimeRecordRepository repository)
        {
            return _accountId;
        }
    }
}
