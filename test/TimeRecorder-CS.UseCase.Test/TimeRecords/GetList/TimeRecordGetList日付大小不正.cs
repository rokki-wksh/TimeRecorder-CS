using System;
using TimeRecorder_CS.Domain.Models.Accounts;
using TimeRecorder_CS.Domain.Types.DateRanges;
using TimeRecorder_CS.Persister.InMemory.QueryServices.TimeRecordGetList;
using TimeRecorder_CS.Persister.InMemory.Repositories.TimeRecords;
using TimeRecorder_CS.UseCase.TimeRecords.GetList;
using Xunit;

namespace TimeRecorder_CS.UseCase.Test.TimeRecords.GetList
{
    public sealed class TimeRecordGetList日付大小不正
    {
        [Fact]
        public void Execute()
        {
            // Assert.
            Assert.Throws<InvalidDateRangeException>(() =>
                new TimeRecordGetListInputData(
                    accountId: AccountId.Create().ToString(),
                    from: DateTime.Now.AddDays(1),
                    to: DateTime.Now
                    ));
        }
    }
}
