using UserModel = DigitalWallet.Domain.Domain.Entities.User;
using DigitalWallet.Application.UseCases.DTOs.Abstractions;

namespace DigitalWallet.Application.UseCases.Wallet.Commands.Deposit
{
    public class DepositResponse : WalletResponseDTO
    {
        public DepositResponse(UserModel user) : base(user) { }
    }
}
