using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace DigitalWalletApi.Models
{
    public class Transfer
    {
        [Key]
        public Guid Id { get; set; }

        public Guid SenderId { get; set; }

        [ForeignKey("SenderId")]
        public User Sender { get; set; }

        public Guid ReceiverId { get; set; }

        [ForeignKey("ReceiverId")]
        public User Receiver { get; set; }

        public DateTime Moment { get; set; }

        public Transfer() { }

        public Transfer(Guid senderId, Guid receiverId)
        {
            Id = Guid.NewGuid();
            SenderId = senderId;
            ReceiverId = receiverId;
            Moment = DateTime.UtcNow;
        }
    }
}
