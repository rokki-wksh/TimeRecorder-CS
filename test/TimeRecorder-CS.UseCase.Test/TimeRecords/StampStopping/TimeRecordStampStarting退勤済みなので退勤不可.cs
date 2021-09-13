using TimeRecorder_CS.Domain.Services.TimeRecorders;
using TimeRecorder_CS.Domain.Types.TimeRecorders;
using TimeRecorder_CS.Persister.InMemory.Repositories.TimeRecords;
using TimeRecorder_CS.UseCase.TimeRecords.StampStopping;
using Xunit;

namespace TimeRecorder_CS.UseCase.Test.TimeRecords.StampStopping
{
    public sealed class TimeRecordStampStopping退勤済みなので退勤不可
    {
        private readonly TimeRecordRepository _repository;
        private readonly TimeRecorder _timeRecorder;
        private readonly TimeRecordStampStoppingPresenter _presenter;
        private readonly TimeRecordStampStoppingUseCase _usecase;

        public TimeRecordStampStopping退勤済みなので退勤不可()
        {
            // Create target instances.
            _repository = new();
            _timeRecorder = new(_repository);
            _presenter = new();
            _usecase = new(_timeRecorder, _repository, _presenter);
        }

        [Fact]
        public void Execute()
        {
            _repository.Create退勤Data();

            // Create input data.
            var accountId = _repository.TestAccountId();
            var input = new TimeRecordStampStoppingInputData(accountId.ToString());

            // Assert.
            Assert.Throws<TimeRecordCannotStampStoppingException>(() => _usecase.Execute(input));
        }
    }
}
