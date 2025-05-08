using DigitalWalletApi.Domain.Entities;
using DigitalWalletApi.DTOs.Abstractions;
using System.ComponentModel.DataAnnotations;
namespace DigitalWalletApi.DTOs.Entities
{
    public class TransferDTO : EntityDTO
    {
        [Required(ErrorMessage = "É necessário informar quem está realizando a transação.")]
        public Guid SenderId { get; set; }

        public UserDTO? Sender { get; set; }

        [Required(ErrorMessage = "É necessário informar quem está recebendo a transação.")]
        public Guid ReceiverId { get; set; }
        public UserDTO? Receiver { get; set; }

        [Required(ErrorMessage = "O valor deve ser informado.")]
        public decimal Amount { get; private set; }

        public DateTime Moment { get; set; }

        public TransferDTO() { }

        public TransferDTO(Guid id, Guid senderId, Guid receiverId, decimal amount)
        {
            SenderId = senderId;
            ReceiverId = receiverId;
            Moment = DateTime.UtcNow;
            Amount = amount;
        }

        public TransferDTO(Transfer transfer)
        {
            SenderId = transfer.SenderId;
            ReceiverId = transfer.ReceiverId;
            Moment = transfer.Moment;
            Amount = transfer.Amount;
            Sender = new UserDTO(transfer.Sender);
            Receiver = new UserDTO(transfer.Receiver);
        }
    }
}
