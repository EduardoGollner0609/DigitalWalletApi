using System.ComponentModel.DataAnnotations.Schema;
using DigitalWalletApi.Domain.Abstractions;

namespace DigitalWalletApi.Domain.Entities
{
    public class Transfer : Entity
    {
        public Guid SenderId { get; private set; }

        [ForeignKey("SenderId")]
        public User Sender { get; private set; }

        public Guid ReceiverId { get; private set; }

        [ForeignKey("ReceiverId")]
        public User Receiver { get; private set; }
        public decimal Amount { get; private set; }

        public DateTime Moment { get; private set; }

        public Transfer() { }

        public Transfer(Guid senderId, Guid receiverId, decimal amount)
        {
            SenderId = senderId;
            ReceiverId = receiverId;
            Amount = amount;
            Moment = DateTime.UtcNow;
        }
    }
}
