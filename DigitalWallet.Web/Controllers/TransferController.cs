using DigitalWallet.Application.UseCases.Exceptions;
using DigitalWallet.Application.UseCases.Transfer.Commands.CreateTransfer;
using DigitalWallet.Web.DTOs;
using DigitalWallet.Web.DTOs.Inserts;
using DigitalWallet.Web.DTOs.Responses;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Security.Claims;

namespace DigitalWallet.Web.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TransferController : ControllerBase
    {
        private readonly CreateTransferHandler _createTransferHandler;

        public TransferController(CreateTransferHandler createTransferHandler)
        {
            _createTransferHandler = createTransferHandler;
        }

        [Authorize]
        [HttpPost]
        public async Task<ActionResult<TransferSimpleDTO>> CreateTransferAsync([FromBody] TransferInsertDTO dto)
        {
            try
            {
                Guid userId = Guid.Parse(HttpContext.User.FindFirstValue(ClaimTypes.NameIdentifier));
                var command = new CreateTransferCommand(userId, dto.ReceiverId, dto.Amount);
                var response = await _createTransferHandler.HandleAsync(command);

                TransferSimpleDTO transfer = CreateResponseDTO(response);

                return Created(string.Empty, transfer);
            }
            catch (CreateEntityException e)
            {
                return BadRequest(e.Message);
            }
        }

        private TransferSimpleDTO CreateResponseDTO(CreateTransferResponse response)
        {
            return new TransferSimpleDTO(
                    response.Id,
                    new UserSimpleDTO(
                        response.Sender.Id,
                        response.Sender.Name,
                        response.Sender.Email
                    ),
                     new UserSimpleDTO(
                        response.Receiver.Id,
                        response.Receiver.Name,
                        response.Receiver.Email
                    ),
                    response.Amount,
                    response.Moment);
        }
    }
}