using TransferModel = DigitalWallet.Domain.Domain.Entities.Transfer;
using DigitalWallet.Application.UseCases.DTOs;

namespace DigitalWallet.Application.UseCases.Transfer.Commands.CreateTransfer
{
    public class CreateTransferResponse : TransferSimpleDTO
    {
        public CreateTransferResponse(TransferModel transfer) : base(transfer) { }
    }
}
