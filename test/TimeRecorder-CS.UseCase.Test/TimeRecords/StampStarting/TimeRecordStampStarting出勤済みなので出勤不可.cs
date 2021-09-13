using TimeRecorder_CS.Domain.Services.TimeRecorders;
using TimeRecorder_CS.Domain.Types.TimeRecorders;
using TimeRecorder_CS.Persister.InMemory.Repositories.TimeRecords;
using TimeRecorder_CS.UseCase.TimeRecords.StampStarting;
using Xunit;

namespace TimeRecorder_CS.UseCase.Test.TimeRecords.StampStarting
{
    public sealed class TimeRecordStampStarting出勤済みなので出勤不可
    {
        private readonly TimeRecordRepository _repository;
        private readonly TimeRecorder _timeRecorder;
        private readonly TimeRecordStampStartingPresenter _presenter;
        private readonly TimeRecordStampStartingUseCase _usecase;

        public TimeRecordStampStarting出勤済みなので出勤不可()
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
            _repository.CreateTestData();

            // Create input data.
            var accountId = _repository.TestAccountId();
            var input = new TimeRecordStampStartingInputData(accountId.ToString());

            // Assert.
            Assert.Throws<TimeRecordCannotStampStartingException>(() => _usecase.Execute(input));
        }
    }
}
