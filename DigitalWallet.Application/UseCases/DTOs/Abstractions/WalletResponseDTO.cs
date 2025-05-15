using UserModel = DigitalWallet.Domain.Domain.Entities.User;

namespace DigitalWallet.Application.UseCases.DTOs.Abstractions
{
    public abstract class WalletResponseDTO
    {
        public UserSimpleDTO User { get; private set; }
        public decimal Balance { get; private set; }

        public WalletResponseDTO(UserModel user)
        {
            User = new(user);
            Balance = user.Balance;
        }
    }
}
