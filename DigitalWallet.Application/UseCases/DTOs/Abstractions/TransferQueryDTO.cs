namespace DigitalWallet.Application.UseCases.DTOs.Abstractions
{
    public abstract class TransferQueryDTO
    {
        public Guid UserId { get; private set; }
        public DateTime? MinDate { get; private set; }
        public DateTime? MaxDate { get; private set; }
        public int Page { get; private set; }
        public int PageSize { get; private set; }

        public TransferQueryDTO(Guid userId, DateTime? minDate, DateTime? maxDate, int? page, int? pageSize)
        {
            UserId = userId;
            MinDate = minDate;
            MaxDate = maxDate;
            Page = page is null or < 1 ? 1 : page.Value;
            PageSize = pageSize is null or <= 0 ? 10 : pageSize.Value;
        }
    }
}
