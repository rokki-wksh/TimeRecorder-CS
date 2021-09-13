using System;
using TimeRecorder_CS.Persister.InMemory.QueryServices.TimeRecordGetList;
using TimeRecorder_CS.Persister.InMemory.Repositories.TimeRecords;
using TimeRecorder_CS.UseCase.TimeRecords.GetList;
using Xunit;

namespace TimeRecorder_CS.UseCase.Test.TimeRecords.GetList
{
    public sealed class TimeRecordGetList一か月分取得
    {
        private readonly TimeRecordRepository _repository;
        private readonly TimeRecordGetListQueryService _queryService;
        private readonly TimeRecordGetListPresenter _presenter;
        private readonly TimeRecordGetListUseCase _usecase;

        public TimeRecordGetList一か月分取得()
        {
            // Create target instances.
            _repository = new();
            _queryService = new(_repository);
            _presenter = new();
            _usecase = new(_queryService, _presenter);
        }

        [Fact]
        public void Execute()
        {
            _repository.CreateTestData();

            // Create input data.
            var now = DateTime.Now;
            var input = new TimeRecordGetListInputData(
                accountId: _repository.TestAccountId().ToString(),
                from: new DateTime(now.Year, now.Month, 1),
                to: (new DateTime(now.Year, now.Month, 1)).AddMonths(1).AddDays(-1)
                );

            // Execute.
            _usecase.Execute(input);

            // Assert.
            var output = _presenter.Output;
            Assert.Equal(2, output.List.Count);
        }
    }
}
