using TransferModel = DigitalWallet.Domain.Domain.Entities.Transfer;
using DigitalWallet.Application.UseCases.DTOs.Abstractions;

namespace DigitalWallet.Application.UseCases.DTOs
{
    public class TransferSimpleDTO : EntityResponseDTO
    {
        public UserSimpleDTO Sender { get; private set; }

        public UserSimpleDTO Receiver { get; private set; }
        public decimal Amount { get; private set; }

        public DateTime Moment { get; private set; }

        public TransferSimpleDTO(TransferModel transfer)
        {
            base.Id = transfer.Id;
            Moment = transfer.Moment.ToLocalTime();
            Amount = transfer.Amount;
            Sender = new UserSimpleDTO(transfer.Sender);
            Receiver = new UserSimpleDTO(transfer.Receiver);
        }
    }
}
