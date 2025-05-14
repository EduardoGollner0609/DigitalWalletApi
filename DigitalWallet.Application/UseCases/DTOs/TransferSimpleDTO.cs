using TransferModel = DigitalWallet.Domain.Domain.Entities.Transfer;
using DigitalWallet.Application.UseCases.DTOs.Abstractions;

namespace DigitalWallet.Application.UseCases.DTOs
{
    public class TransferSimpleDTO : EntityResponseDTO
    {
        public Guid SenderId { get; private set; }

        public UserSimpleDTO Sender { get; private set; }

        public Guid ReceiverId { get; private set; }
        public UserSimpleDTO Receiver { get; private set; }
        public decimal Amount { get; private set; }

        public DateTime Moment { get; private set; }

        public TransferSimpleDTO(TransferModel transfer)
        {
            base.Id = transfer.Id;
            SenderId = transfer.SenderId;
            ReceiverId = transfer.ReceiverId;
            Moment = transfer.Moment;
            Amount = transfer.Amount;
            Sender = new UserSimpleDTO(transfer.Sender);
            Receiver = new UserSimpleDTO(transfer.Receiver);
        }
    }
}
