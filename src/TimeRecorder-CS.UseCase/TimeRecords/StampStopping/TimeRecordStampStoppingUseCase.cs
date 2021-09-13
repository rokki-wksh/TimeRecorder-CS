using System.Transactions;
using TimeRecorder_CS.Domain.Models.TimeRecords;
using TimeRecorder_CS.Domain.Services.TimeRecorders;

namespace TimeRecorder_CS.UseCase.TimeRecords.StampStopping
{
    public sealed class TimeRecordStampStoppingUseCase
    {
        private readonly TimeRecorder _timeRecorder;
        private readonly ITimeRecordRepository _repository;
        private readonly ITimeRecordStampStoppingPresenter _presenter;

        public TimeRecordStampStoppingUseCase(
            TimeRecorder timeRecorder,
            ITimeRecordRepository repository,
            ITimeRecordStampStoppingPresenter presenter)
        {
            _timeRecorder = timeRecorder;
            _repository = repository;
            _presenter = presenter;
        }

        public void Execute(TimeRecordStampStoppingInputData input)
        {
            TimeRecord stamped;
            using (var tran = new TransactionScope())
            {
                stamped = _timeRecorder.StampStopping(input.AccountId);
                _repository.Save(stamped);

                tran.Complete();
            }

            var output = new TimeRecordStampStoppingOutputData(stamped);

            _presenter.Complete(output);
        }
    }
}
