using DigitalWalletApi.Domain.Entities;
using DigitalWalletApi.Domain.Entities.Enums;

namespace DigitalWalletApi.DTOs.Entities
{
    public class UserAuthenticatedDTO : UserMinDTO
    {
        public string Role { get; private set; }
        public string Token { get; private set; }

        public UserAuthenticatedDTO() { }

        public UserAuthenticatedDTO(User user, Role role, string token) :
        base(user)
        {
            Role = role.ToString();
            Token = token;
        }
    }
}
