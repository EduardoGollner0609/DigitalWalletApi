using DigitalWalletApi.Domain.Entities.Enums;
using DigitalWalletApi.Domain.Entities;

namespace DigitalWalletApi.DTOs.Entities
{
    public class UserAuthenticatedLoginDTO : UserAuthenticatedDTO
    {
        public string Token { get; private set; }

        public UserAuthenticatedLoginDTO() { }

        public UserAuthenticatedLoginDTO(User user, Role role, string token)
            : base(user, role)
        {
            Token = token;
        }
    }
}
