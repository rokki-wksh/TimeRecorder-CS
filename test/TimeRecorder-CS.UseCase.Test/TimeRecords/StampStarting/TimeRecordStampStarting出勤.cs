using TimeRecorder_CS.Domain.Models.Accounts;
using TimeRecorder_CS.Domain.Models.TimeRecords;
using TimeRecorder_CS.Domain.Services.TimeRecorders;
using TimeRecorder_CS.Persister.InMemory.Repositories.TimeRecords;
using TimeRecorder_CS.UseCase.TimeRecords.StampStarting;
using Xunit;

namespace TimeRecorder_CS.UseCase.Test.TimeRecords.StampStarting
{
    public sealed class TimeRecordStampStarting出勤
    {
        private readonly TimeRecordRepository _repository;
        private readonly TimeRecorder _timeRecorder;
        private readonly TimeRecordStampStartingPresenter _presenter;
        private readonly TimeRecordStampStartingUseCase _usecase;

        public TimeRecordStampStarting出勤()
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
            // Create input data.
            var accountId = AccountId.Create();
            var input = new TimeRecordStampStartingInputData(accountId.ToString());

            // Execute.
            _usecase.Execute(input);

            //Assert.
            var output = _presenter.Output;

            Assert.True(
                accountId.ToString() == output.AccountId.ToString() &&
                TimeRecordType.出勤.Id == output.TimeRecordTypeId
                );
        }
    }
}
