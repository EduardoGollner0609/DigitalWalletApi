using System.ComponentModel.DataAnnotations.Schema;
using DigitalWalletApi.Domain.Abstractions;

namespace DigitalWalletApi.Domain.Entities
{
    public class Transfer : Entity
    {
        public Guid SenderId { get; private set; }
        public Guid ReceiverId { get; private set; }
        public decimal Amount { get; private set; }

        [Column(TypeName = "timestamp with time zone")]
        public DateTime Moment { get; private set; }

        [ForeignKey("SenderId")]
        [InverseProperty("TransfersSent")]
        public User Sender { get; private set; }

        [ForeignKey("ReceiverId")]
        [InverseProperty("TransfersReceived")]
        public User Receiver { get; private set; }

        public Transfer() { }

        public Transfer(Guid senderId, Guid receiverId, decimal amount, DateTime moment)
        {
            base.Id = Guid.NewGuid();
            SenderId = senderId;
            ReceiverId = receiverId;
            Amount = amount;
            Moment = moment;
        }
    }
}
