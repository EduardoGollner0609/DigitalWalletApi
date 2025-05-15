using UserModel = DigitalWallet.Domain.Domain.Entities.User;
using DigitalWallet.Domain.Repositories.Abstractions;

namespace DigitalWallet.Application.UseCases.Wallet.Queries.GetBalance
{
    public class GetBalanceHandler
    {

        private readonly IUserRepository _userRepository;

        public GetBalanceHandler(IUserRepository userRepository)
        {
            _userRepository = userRepository;
        }

        public async Task<GetBalanceResponse> HandleAsync(GetBalanceQuery query)
        {
            UserModel user = await _userRepository.FindByIdAsync(query.UserId);

            if (user == null)
                throw new UnauthorizedAccessException("Erro ao consultar saldo: Token inválido.");

            return new GetBalanceResponse(user);
        }
    }
}
