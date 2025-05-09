using DigitalWalletApi.DTOs.Abstractions;
using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;

namespace DigitalWalletApi.DTOs.Entities
{
    public class TransferMinDTO : EntityDTO
    {
        [Required(ErrorMessage = "É necessário informar quem está realizando a transação.")]
        public Guid SenderId { get; private set; }

        [Required(ErrorMessage = "É necessário informar quem está recebendo a transação.")]
        public Guid ReceiverId { get; private set; }

        [Required(ErrorMessage = "O valor deve ser informado.")]
        public decimal Amount { get; private set; }

        public DateTime Moment { get; private set; }

        public TransferMinDTO() { }

        [JsonConstructor]
        public TransferMinDTO(Guid id, Guid receiverId, decimal amount)
        {
            ReceiverId = receiverId;
            Amount = amount;
        }

        public void SetSenderId(Guid id)
        {
            SenderId = id;
        }
    }
}
