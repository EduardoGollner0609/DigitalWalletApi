
namespace DigitalWallet.Application.UseCases.Exceptions
{
    public class ResourceNotFoundException : ApplicationException
    {
        public ResourceNotFoundException() { }
        public ResourceNotFoundException(string message) : base(message) { }
    }
}
