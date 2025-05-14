using UserModel = DigitalWallet.Domain.Domain.Entities.User;

namespace DigitalWallet.Application.UseCases.Abstractions
{
    public interface ITokenService
    {
        string GetToken(UserModel user);
    }
}
