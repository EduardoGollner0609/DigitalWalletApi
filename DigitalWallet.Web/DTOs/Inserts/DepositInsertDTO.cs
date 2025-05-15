namespace DigitalWallet.Web.DTOs.Inserts
{
    public class DepositInsertDTO
    {
        public decimal Amount { get; private set; }

        public DepositInsertDTO(decimal amount)
        {
            Amount = amount;
        }
    }
}
