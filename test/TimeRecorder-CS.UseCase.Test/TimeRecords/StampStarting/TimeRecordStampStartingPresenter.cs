using TimeRecorder_CS.UseCase.TimeRecords.StampStarting;

namespace TimeRecorder_CS.UseCase.Test.TimeRecords.StampStarting
{
    internal sealed class TimeRecordStampStartingPresenter : ITimeRecordStampStartingPresenter
    {
        public TimeRecordStampStartingOutputData Output { get; set; }

        public void Complete(TimeRecordStampStartingOutputData output)
        {
            Output = output;
        }
    }
}
