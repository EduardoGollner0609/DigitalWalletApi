using UserModel = DigitalWallet.Domain.Domain.Entities.User;
using DigitalWallet.Application.UseCases.DTOs.Abstractions;

namespace DigitalWallet.Application.UseCases.DTOs
{
    public class UserSimpleDTO : EntityResponseDTO
    {
        public string Name { get; private set; }
        public string Email { get; private set; }

        public UserSimpleDTO(UserModel user)
        {
            base.Id = user.Id;
            Name = $"{user.FirstName} {user.LastName}";
            Email = user.Email;
        }
    }
}
