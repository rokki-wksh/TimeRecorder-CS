using TimeRecorder_CS.UseCase.TimeRecords.GetList;

namespace TimeRecorder_CS.UseCase.Test.TimeRecords.GetList
{
    internal sealed class TimeRecordGetListPresenter : ITimeRecordGetListPresenter
    {
        public TimeRecordGetListOutputData Output { get; set; }

        public void Complete(TimeRecordGetListOutputData output)
        {
            Output = output;
        }
    }
}
