using DigitalWalletApi.Domain.Entities;

namespace DigitalWalletApi.DTOs.Entities
{
    public class UserAuthenticatedDTO : UserMinDTO
    {
        public string Role { get; private set; }
        public string Token { get; private set; }

        public UserAuthenticatedDTO() { }

        public UserAuthenticatedDTO(User user, string role, string token) :
        base(user)
        {
            Role = role;
            Token = token;
        }
    }
}
