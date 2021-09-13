using System;
using TimeRecorder_CS.Domain.Models.Accounts;
using TimeRecorder_CS.Domain.Models.TimeRecords;

namespace TimeRecorder_CS.UseCase.Test.TimeRecords.StampStopping
{
    internal static class CreateTestDataExtension
    {
        private static readonly AccountId _accountId = AccountId.Create();

        internal static void Create出勤Data(this ITimeRecordRepository repository)
        {
            var 出勤 = TimeRecord.Create(_accountId, TimeRecordType.出勤);
            repository.Save(出勤);
        }

        internal static void Create退勤Data(this ITimeRecordRepository repository)
        {
            var 出勤 = TimeRecord.Create(_accountId, TimeRecordType.出勤);
            repository.Save(出勤);

            var 退勤 = TimeRecord.From(
                timeRecordId: TimeRecordId.Create().ToString(),
                accountId: _accountId.ToString(),
                timeRecordType: TimeRecordType.退勤.Id,
                recordedDateTime: DateTime.Now
                );
            repository.Save(退勤);
        }

        internal static AccountId TestAccountId(this ITimeRecordRepository repository)
        {
            return _accountId;
        }
    }
}
