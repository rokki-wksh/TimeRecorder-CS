namespace TimeRecorder_CS.UseCase.TimeRecords.GetList
{
    public sealed class TimeRecordGetListUseCase
    {
        private readonly ITimeRecordGetListQueryService _queryService;
        private readonly ITimeRecordGetListPresenter _presenter;

        public TimeRecordGetListUseCase(
            ITimeRecordGetListQueryService queryService,
            ITimeRecordGetListPresenter presenter)
        {
            _queryService = queryService;
            _presenter = presenter;
        }

        public void Execute(TimeRecordGetListInputData input)
        {
            var timeCard = _queryService.Query(
                accountId: input.AccountId,
                from: input.From,
                to: input.To);

            var output = new TimeRecordGetListOutputData(timeCard);

            _presenter.Complete(output);
        }
    }
}
