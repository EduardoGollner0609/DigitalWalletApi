
using DigitalWallet.Domain.Domain.Entities;
using DigitalWallet.Web.DTOs.Abstractions;

namespace DigitalWallet.Web.DTOs
{
    public class TransferSimpleDTO : EntityResponseDTO
    {
        public Guid SenderId { get; private set; }

        public UserSimpleDTO Sender { get; private set; }

        public Guid ReceiverId { get; private set; }
        public UserSimpleDTO Receiver { get; private set; }
        public decimal Amount { get; private set; }

        public DateTime Moment { get; private set; }

        public TransferSimpleDTO(Transfer transfer)
        {
            base.Id = transfer.Id;
            SenderId = transfer.SenderId;
            ReceiverId = transfer.ReceiverId;
            Moment = transfer.Moment;
            Amount = transfer.Amount;
            Sender = new UserSimpleDTO(transfer.Sender);
            Receiver = new UserSimpleDTO(transfer.Receiver);
        }

        public TransferSimpleDTO(Guid id, UserSimpleDTO sender, UserSimpleDTO receiver, decimal amount, DateTime moment)
        {
            base.Id = id;
            SenderId = sender.Id;
            Sender = sender;
            ReceiverId = receiver.Id;
            Receiver = receiver;
            Amount = amount;
            Sender = sender;
            Receiver = receiver;
        }
    }
}
