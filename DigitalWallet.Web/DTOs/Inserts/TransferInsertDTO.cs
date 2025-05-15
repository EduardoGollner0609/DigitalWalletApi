using System.ComponentModel.DataAnnotations;

namespace DigitalWallet.Web.DTOs.Inserts
{
    public class TransferInsertDTO
    {
        [Required(ErrorMessage = "É necessário informar quem está recebendo a transação.")]
        public Guid ReceiverId { get; private set; }
        [Required(ErrorMessage = "O valor deve ser informado.")]
        public decimal Amount { get; private set; }

        public TransferInsertDTO() { }

        public TransferInsertDTO(Guid receiverId, decimal amount)
        {
            ReceiverId = receiverId;
            Amount = amount;
        }
    }
}
