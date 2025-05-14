using UserModel = DigitalWallet.Domain.Domain.Entities.User;
using DigitalWallet.Application.UseCases.DTOs;

namespace DigitalWallet.Application.UseCases.Wallet.Commands.Deposit
{
    public class DepositResponse
    {
        public UserSimpleDTO User { get; private set; }
        public decimal NewBalance { get; private set; }

        public DepositResponse(UserModel user)
        {
            User = new(user);
            NewBalance = user.Balance;
        }
    }
}
