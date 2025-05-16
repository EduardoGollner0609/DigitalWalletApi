using TransferModel = DigitalWallet.Domain.Domain.Entities.Transfer;
using DigitalWallet.Application.UseCases.DTOs;
using DigitalWallet.Domain.Repositories.Abstractions;
using DigitalWallet.Application.UseCases.Transfer.Queries.GetSentTranfers;

namespace DigitalWallet.Application.UseCases.Transfer.Queries
{
    public class GetTransfersHandler
    {
        private readonly ITransferRepository _transferRepository;
        private readonly IUserRepository _userRepository;

        public GetTransfersHandler(IUserRepository userRepository, ITransferRepository transferRepository)
        {
            _userRepository = userRepository;
            _transferRepository = transferRepository;
        }

        public async Task<List<TransferSimpleDTO>> HandleAsync(GetTransfersQuery query)
        {
            List<TransferModel> transfers = await _transferRepository
                .GetTransfers(query.UserId, query.MinDate, query.MaxDate, query.Page, query.PageSize);
            return transfers.Select(t => new TransferSimpleDTO(t)).ToList();
        }
    }
}
