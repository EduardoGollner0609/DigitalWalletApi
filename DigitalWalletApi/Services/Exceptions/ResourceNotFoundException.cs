namespace DigitalWalletApi.Services.Exceptions
{
    public class ResourceNotFoundException : ApplicationException
    {
        public ResourceNotFoundException() { }
        public ResourceNotFoundException(string msg) : base(msg) { }
    }
}
