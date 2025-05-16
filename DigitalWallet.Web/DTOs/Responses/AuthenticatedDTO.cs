using DigitalWallet.Domain.Domain.Entities.Enums;

namespace DigitalWallet.Web.DTOs.Responses
{
    public class AuthenticatedDTO
    {
        public UserSimpleDTO User { get; private set; }
        public string Role { get; private set; }
        public string Token { get; private set; }

        public AuthenticatedDTO(UserSimpleDTO user, string role, string token)
        {
            User = user;
            Role = role;
            Token = token;
        }
    }
}
