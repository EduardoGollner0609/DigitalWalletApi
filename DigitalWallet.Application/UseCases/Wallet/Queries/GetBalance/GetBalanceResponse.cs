using UserModel = DigitalWallet.Domain.Domain.Entities.User;
using DigitalWallet.Application.UseCases.DTOs;
using DigitalWallet.Application.UseCases.DTOs.Abstractions;

namespace DigitalWallet.Application.UseCases.Wallet.Queries.GetBalance
{
    public class GetBalanceResponse : WalletResponseDTO
    {
        public UserSimpleDTO User { get; private set; }
        public decimal Balance { get; private set; }

        public GetBalanceResponse(UserModel user) : base(user) { }
    }
}
