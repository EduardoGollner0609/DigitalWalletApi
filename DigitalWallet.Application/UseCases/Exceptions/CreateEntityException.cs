
namespace DigitalWallet.Application.UseCases.Exceptions
{
    public class CreateEntityException : ApplicationException
    {
        public CreateEntityException() { }
        public CreateEntityException(string message) : base(message) { }
    }
}
