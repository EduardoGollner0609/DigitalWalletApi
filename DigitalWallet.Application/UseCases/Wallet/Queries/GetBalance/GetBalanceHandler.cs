using UserModel = DigitalWallet.Domain.Domain.Entities.User;
using DigitalWallet.Domain.Repositories.Abstractions;
using DigitalWallet.Application.UseCases.Exceptions;

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
                throw new ResourceNotFoundException("Erro ao consultar saldo: Usuário não foi encontrado!");

            return new GetBalanceQuery(user);
        }
    }
}
