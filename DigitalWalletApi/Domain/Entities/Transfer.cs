using System.ComponentModel.DataAnnotations.Schema;
using DigitalWalletApi.Domain.Abstractions;

namespace DigitalWalletApi.Domain.Entities
{
    public class Transfer : Entity
    {
        public Guid SenderId { get; set; }

        [ForeignKey("SenderId")]
        public User Sender { get; set; }

        public Guid ReceiverId { get; set; }

        [ForeignKey("ReceiverId")]
        public User Receiver { get; set; }

        public DateTime Moment { get; set; }

        public Transfer() { }

        public Transfer(Guid id, Guid senderId, Guid receiverId) : base()
        {
            SenderId = senderId;
            ReceiverId = receiverId;
            Moment = DateTime.UtcNow;
        }
    }
}
