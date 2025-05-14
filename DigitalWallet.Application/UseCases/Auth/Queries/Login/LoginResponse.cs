using UserModel = DigitalWallet.Domain.Domain.Entities.User;
using DigitalWallet.Application.UseCases.DTOs;
using DigitalWallet.Domain.Domain.Entities.Enums;

namespace DigitalWallet.Application.UseCases.Auth.Queries.Login
{
    public class LoginResponse
    {
        public UserSimpleDTO User { get; private set; }
        public Role Role { get; private set; }
        public string Token { get; private set; }

        public LoginResponse(UserModel user, string token)
        {
            User = new UserSimpleDTO(user);
            Role = user.Role;
            Token = token;
        }
    }
}
