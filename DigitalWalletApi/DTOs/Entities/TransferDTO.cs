using DigitalWalletApi.Domain.Entities;
using DigitalWalletApi.DTOs.Abstractions;
using System.ComponentModel.DataAnnotations;
namespace DigitalWalletApi.DTOs.Entities
{
    public class TransferDTO : EntityDTO
    {
        [Required(ErrorMessage = "É necessário informar quem está realizando a transação.")]
        public Guid SenderId { get; set; }

        public User? Sender { get; set; }

        [Required(ErrorMessage = "É necessário informar quem está recebendo a transação.")]
        public Guid ReceiverId { get; set; }
        public User? Receiver { get; set; }

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
    }
}
