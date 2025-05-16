using System.ComponentModel.DataAnnotations;

namespace DigitalWallet.Web.DTOs.Inserts
{
    public class TransferInsertDTO
    {
        [Required(ErrorMessage = "É necessário informar quem está recebendo a transação.")]
        public Guid ReceiverId { get; private set; }
        [Required(ErrorMessage = "O valor deve ser informado.")]
        [Range(0.1, double.MaxValue, ErrorMessage = "O valor deve ser maior que zero")]
        public decimal Amount { get; private set; }

        public TransferInsertDTO(Guid receiverId, decimal amount)
        {
            ReceiverId = receiverId;
            Amount = amount;
        }
    }
}
