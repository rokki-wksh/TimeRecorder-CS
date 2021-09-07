using System;
using TimeRecorder_CS.Domain.Models.Accounts;

namespace TimeRecorder_CS.Domain.Models.TimeRecords
{
    public sealed class TimeRecord
    {
        private readonly TimeRecordId _timeRecordId;
        private readonly AccountId _accountId;
        private readonly TimeRecordType _timeRecordType;
        private readonly RecordedDateTime _recordedDateTime;

        private TimeRecord(TimeRecordId timeRecordId, AccountId accountId, TimeRecordType timeRecordType, RecordedDateTime recordedDateTime)
        {
            _timeRecordId = timeRecordId;
            _accountId = accountId;
            _timeRecordType = timeRecordType;
            _recordedDateTime = recordedDateTime;
        }

        public static TimeRecord From(string timeRecordId, string accountId, byte timeRecordType, DateTime recordedDateTime)
        {
            return new(
                timeRecordId: TimeRecordId.From(timeRecordId),
                accountId: AccountId.From(accountId),
                timeRecordType: TimeRecordType.From(timeRecordType),
                recordedDateTime: RecordedDateTime.From(recordedDateTime)
                );
        }

        public static TimeRecord Create(AccountId accountId, TimeRecordType timeRecordType)
        {
            return new(
                timeRecordId: TimeRecordId.Create(),
                accountId: accountId,
                timeRecordType: timeRecordType,
                recordedDateTime: RecordedDateTime.Create()
                );
        }

        public bool Is(TimeRecordType timeRecordType)
        {
            return _timeRecordType.Is(timeRecordType);
        }

        public bool Before(TimeRecord other)
        {
            return _recordedDateTime.Before(other._recordedDateTime);
        }

        public TimeRecordId TimeRecordId => _timeRecordId;

        public TimeRecordDTO ToDTO()
        {
            return new TimeRecordDTO(
                timeRecordId: _timeRecordId.Value,
                accountId: _accountId.Value,
                timeRecordTypeId: _timeRecordType.Id,
                timeRecordTypeName: _timeRecordType.Name,
                recordedDateTime: _recordedDateTime.Value
                );
        }
    }
}
