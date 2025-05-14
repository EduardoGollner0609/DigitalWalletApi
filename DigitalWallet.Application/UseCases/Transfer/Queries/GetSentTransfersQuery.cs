
namespace DigitalWallet.Application.UseCases.Transfer.Queries
{
    public class GetSentTransfersQuery
    {
        public Guid UserId { get; private set; }
        public DateTime? MinDate { get; private set; }
        public DateTime? MaxDate { get; private set; }

        public GetSentTransfersQuery(Guid userId, DateTime minDate, DateTime maxDate)
        {
            UserId = userId;
            MinDate = minDate;
            MaxDate = maxDate;
        }
    }
}
