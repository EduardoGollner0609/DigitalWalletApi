using System.ComponentModel.DataAnnotations;

namespace DigitalWalletApi.Domain.Abstractions
{
    public abstract class Entity
    {
        [Key]
        public Guid Id { get; private set; }

        public Entity()
        {
            Id = Guid.NewGuid();
        }
    }
}
