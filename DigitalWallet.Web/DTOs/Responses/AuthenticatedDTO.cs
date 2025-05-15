using DigitalWallet.Domain.Domain.Entities.Enums;

namespace DigitalWallet.Web.DTOs.Responses
{
    public class AuthenticatedDTO
    {
        public UserSimpleDTO User { get; private set; }
        public Role Role { get; private set; }
        public string Token { get; private set; }

        public AuthenticatedDTO(UserSimpleDTO user, Role role, string token)
        {
            User = user;
            Role = role;
            Token = token;
        }
    }
}
