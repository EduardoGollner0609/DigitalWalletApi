using UserModel = DigitalWallet.Domain.Domain.Entities.User;
using DigitalWallet.Application.UseCases.DTOs;

namespace DigitalWallet.Application.UseCases.Wallet.Queries.GetBalance
{
    public class GetBalanceResponse
    {
        public UserSimpleDTO User { get; private set; }
        public decimal Balance { get; private set; }

        public GetBalanceResponse(UserModel user)
        {
            User = new(user);
            Balance = user.Balance;
        }
    }
}
