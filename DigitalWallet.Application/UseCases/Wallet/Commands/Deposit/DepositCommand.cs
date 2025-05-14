
namespace DigitalWallet.Application.UseCases.Wallet.Commands.Deposit
{
    public class DepositCommand
    {
        public Guid UserId { get; private set; }
        public decimal Amount { get; private set; }

        public DepositCommand(Guid userId, decimal amount)
        {
            UserId = userId;
            Amount = amount;
        }
    }
}
