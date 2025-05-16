using TransferModel = DigitalWallet.Domain.Domain.Entities.Transfer;
using DigitalWallet.Application.UseCases.DTOs;
using DigitalWallet.Domain.Repositories.Abstractions;

namespace DigitalWallet.Application.UseCases.Transfer.Queries.GetSentTranfers
{
    public class GetSentTransfersHandler
    {
        private readonly ITransferRepository _transferRepository;
        private readonly IUserRepository _userRepository;

        public GetSentTransfersHandler(IUserRepository userRepository, ITransferRepository transferRepository)
        {
            _userRepository = userRepository;
            _transferRepository = transferRepository;
        }

        public async Task<List<TransferSimpleDTO>> HandleAsync(GetSentTransfersQuery query)
        {
            List<TransferModel> transfers = await _transferRepository
                .FindSentTransfersByUserId(query.UserId, query.MinDate, query.MaxDate, query.Page, query.PageSize);
            return transfers.Select(t => new TransferSimpleDTO(t)).ToList();
        }
    }
}
