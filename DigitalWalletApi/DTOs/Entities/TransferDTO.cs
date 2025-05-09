using DigitalWalletApi.Domain.Entities;
using DigitalWalletApi.DTOs.Abstractions;
using System.ComponentModel.DataAnnotations;

namespace DigitalWalletApi.DTOs.Entities
{
    public class TransferDTO : EntityDTO
    {
        public Guid SenderId { get; private set; }

        public UserMinDTO Sender { get; private set; }

        public Guid ReceiverId { get; private set; }
        public UserMinDTO Receiver { get; private set; }

        [Required(ErrorMessage = "O valor deve ser informado.")]
        public decimal Amount { get; private set; }

        public DateTime Moment { get; private set; }

        public TransferDTO() { }

        public TransferDTO(Guid senderId, Guid receiverId, decimal amount, DateTime moment)
        {
            SenderId = senderId;
            ReceiverId = receiverId;
            Amount = amount;
            Moment = moment;
        }

        public TransferDTO(Transfer transfer)
        {
            base.Id = transfer.Id;
            SenderId = transfer.SenderId;
            ReceiverId = transfer.ReceiverId;
            Moment = transfer.Moment;
            Amount = transfer.Amount;
            Sender = new UserMinDTO(transfer.Sender);
            Receiver = new UserMinDTO(transfer.Receiver);
        }
    }
}
