namespace DigitalWalletApi.Services.Exceptions
{
    public class CreateEntityException : ApplicationException
    {
        public CreateEntityException() { }

        public CreateEntityException(string msg) : base(msg) { }
    }
}
