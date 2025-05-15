using UserModel = DigitalWallet.Domain.Domain.Entities.User;
using DigitalWallet.Application.UseCases.DTOs;
using DigitalWallet.Application.UseCases.DTOs.Abstractions;

namespace DigitalWallet.Application.UseCases.Wallet.Commands.Deposit
{
    public class DepositResponse : WalletResponseDTO
    {
        public UserSimpleDTO User { get; private set; }
        public decimal NewBalance { get; private set; }

        public DepositResponse(UserModel user) : base(user) { }
    }
}
