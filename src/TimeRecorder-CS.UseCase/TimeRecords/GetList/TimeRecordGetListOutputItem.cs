using System;

namespace TimeRecorder_CS.UseCase.TimeRecords.GetList
{
    public sealed class TimeRecordGetListOutputItem
    {
        private readonly string _timeRecordId;
        private readonly string _accountId;
        private readonly byte _timeRecordTypeId;
        private readonly string _timeRecordTypeName;
        private readonly DateTime _recordedDateTime;

        internal TimeRecordGetListOutputItem(
            string timeRecordId,
            string accountId,
            byte timeRecordTypeId,
            string timeRecordTypeName,
            DateTime recordedDateTime
            )
        {
            _timeRecordId = timeRecordId;
            _accountId = accountId;
            _timeRecordTypeId = timeRecordTypeId;
            _timeRecordTypeName = timeRecordTypeName;
            _recordedDateTime = recordedDateTime;
        }

        public string TimeRecordId => _timeRecordId;
        public string AccountId => _accountId;
        public byte TimeRecordTypeId => _timeRecordTypeId;
        public string TimeRecordTypeName => _timeRecordTypeName;
        public DateTime RecordedDateTime => _recordedDateTime;
    }
}
