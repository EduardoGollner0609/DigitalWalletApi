namespace DigitalWallet.Web.DTOs.Responses
{
    public class UserWithBalanceDTO
    {
        public UserSimpleDTO User { get; set; }
        public decimal Balance { get; set; }

        public UserWithBalanceDTO(UserSimpleDTO user, decimal balance)
        {
            User = user;
            Balance = balance;
        }
}
}
