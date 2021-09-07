using System.Transactions;
using TimeRecorder_CS.Domain.Models.TimeRecords;
using TimeRecorder_CS.Domain.Services;

namespace TimeRecorder_CS.UseCase.TimeRecords.StampStarting
{
    public sealed class TimeRecordStampStartingUseCase
    {
        private readonly TimeRecorder _timeRecorder;
        private readonly ITimeRecordRepository _repository;
        private readonly ITimeRecordStampStartingPresenter _presenter;

        public TimeRecordStampStartingUseCase(
            TimeRecorder timeRecorder,
            ITimeRecordRepository repository,
            ITimeRecordStampStartingPresenter presenter)
        {
            _timeRecorder = timeRecorder;
            _repository = repository;
            _presenter = presenter;
        }

        public void Execute(TimeRecordStampStartingInputData input)
        {
            TimeRecord stamped;
            using (var tran = new TransactionScope())
            {
                stamped = _timeRecorder.StampStarting(input.AccountId);
                _repository.Save(stamped);

                tran.Complete();
            }

            var output = new TimeRecordStampStartingOutputData(stamped);

            _presenter.Complete(output);
        }
    }
}
