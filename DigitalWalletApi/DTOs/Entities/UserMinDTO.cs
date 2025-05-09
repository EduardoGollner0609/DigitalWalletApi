using DigitalWalletApi.Domain.Entities;
using DigitalWalletApi.DTOs.Abstractions;

namespace DigitalWalletApi.DTOs.Entities
{
    public class UserMinDTO : EntityDTO
    {
        public string Name { get; private set; }
        public string Email { get; private set; }
        public decimal Balance { get; private set; }

        public UserMinDTO() { }

        public UserMinDTO(User user)
        {
            base.Id = user.Id;
            Name = $"{user.FirstName} {user.LastName}";
            Email = user.Email;
            Balance = user.Balance;
        }

        public void Deposit(decimal amount)
        {
            Balance += amount;
        }
    }
}
