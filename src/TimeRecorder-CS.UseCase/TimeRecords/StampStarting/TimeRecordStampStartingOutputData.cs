using System;
using TimeRecorder_CS.Domain.Models.TimeRecords;

namespace TimeRecorder_CS.UseCase.TimeRecords.StampStarting
{
    public sealed class TimeRecordStampStartingOutputData
    {
        private readonly string _timeRecordId;
        private readonly string _accountId;
        private readonly byte _timeRecordTypeId;
        private readonly string _timeRecordTypeName;
        private readonly DateTime _recordedDateTime;

        internal TimeRecordStampStartingOutputData(TimeRecord timeRecord)
        {
            var dto = timeRecord.ToDTO();

            _timeRecordId = dto.TimeRecordId;
            _accountId = dto.AccountId;
            _timeRecordTypeId = dto.TimeRecordTypeId;
            _timeRecordTypeName = dto.TimeRecordTypeName;
            _recordedDateTime = dto.RecordedDateTime;
        }

        public string TimeRecordId => _timeRecordId;
        public string AccountId => _accountId;
        public byte TimeRecordTypeId => _timeRecordTypeId;
        public string TimeRecordTypeName => _timeRecordTypeName;
        public DateTime RecordedDateTime => _recordedDateTime;
    }
}
