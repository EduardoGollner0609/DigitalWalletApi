
namespace DigitalWallet.Application.UseCases.Wallet.Queries.GetBalance
{
    public class GetBalanceQuery
    {
        public Guid UserId { get; private set; }

        public GetBalanceQuery(Guid userId)
        {
            UserId = userId;
        }
    }
}
