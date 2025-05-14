using UserModel = DigitalWallet.Domain.Domain.Entities.User;
using DigitalWallet.Application.UseCases.DTOs;

namespace DigitalWallet.Application.UseCases.User.CreateUser
{
    public class CreateUserResponse : UserSimpleDTO
    {
        public CreateUserResponse(UserModel user) : base(user) { }
    }
}
