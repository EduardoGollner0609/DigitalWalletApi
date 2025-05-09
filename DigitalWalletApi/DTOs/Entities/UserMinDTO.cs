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

        public UserMinDTO(string firstName, string lastName, string email, decimal balance)
        {
            Name = $"{firstName} {lastName}";
            Email = email;
            Balance = balance;
        }

        public UserMinDTO(User user)
        {
            base.Id = user.Id;
            Name = $"{user.FirstName} {user.LastName}";
            Email = user.Email;
            Balance = user.Balance;
        }
    }
}
