using TransferModel = DigitalWallet.Domain.Domain.Entities.Transfer;
using DigitalWallet.Application.UseCases.DTOs;
using DigitalWallet.Domain.Repositories.Abstractions;

namespace DigitalWallet.Application.UseCases.Transfer.Queries
{
    public class GetSentTransfersHandler
    {
        private readonly ITransferRepository _trasnferRepository;
        private readonly IUserRepository _userRepository;

        public GetSentTransfersHandler(IUserRepository userRepository, ITransferRepository trasnferRepository)
        {
            _userRepository = userRepository;
            _trasnferRepository = trasnferRepository;
        }

        public async Task<List<TransferSimpleDTO>> HandleAsync(GetSentTransfersQuery query)
        {
            List<TransferModel> transfers = await _trasnferRepository
                .FindSentTransfersByUserId(query.UserId, query.MinDate, query.MaxDate);
            return transfers.Select(t => new TransferSimpleDTO(t)).ToList();
        }
    }
}
