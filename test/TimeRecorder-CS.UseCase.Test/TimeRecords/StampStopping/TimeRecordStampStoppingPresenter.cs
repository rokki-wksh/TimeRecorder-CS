using TimeRecorder_CS.UseCase.TimeRecords.StampStopping;

namespace TimeRecorder_CS.UseCase.Test.TimeRecords.StampStopping
{
    internal class TimeRecordStampStoppingPresenter : ITimeRecordStampStoppingPresenter
    {
        public TimeRecordStampStoppingOutputData Output { get; set; }

        public void Complete(TimeRecordStampStoppingOutputData output)
        {
            Output = output;
        }
    }
}