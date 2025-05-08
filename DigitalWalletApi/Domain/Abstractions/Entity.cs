using System.ComponentModel.DataAnnotations;

namespace DigitalWalletApi.Domain.Abstractions
{
    public abstract class Entity
    {
        [Key]
        public Guid Id { get; private set; }
        protected void GenerateId()
        {
            Id = Guid.NewGuid();
        }
    }
}
