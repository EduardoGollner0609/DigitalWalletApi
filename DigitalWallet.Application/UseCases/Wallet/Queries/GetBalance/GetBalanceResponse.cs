using UserModel = DigitalWallet.Domain.Domain.Entities.User;
using DigitalWallet.Application.UseCases.DTOs.Abstractions;

namespace DigitalWallet.Application.UseCases.Wallet.Queries.GetBalance
{
    public class GetBalanceResponse : WalletResponseDTO
    {
        public GetBalanceResponse(UserModel user) : base(user) { }
    }
}
