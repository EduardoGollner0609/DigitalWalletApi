using DigitalWallet.Application.UseCases.DTOs.Abstractions;

namespace DigitalWallet.Application.UseCases.Transfer.Queries.GetSentTranfers
{
    public class GetTransfersQuery : TransferQueryDTO
    {
        public GetTransfersQuery(Guid userId, DateTime? minDate, DateTime? maxDate, int? page, int? pageSize)
            : base(userId, minDate, maxDate, page, pageSize) { }
    }
}
