using DigitalWallet.Application.UseCases.Exceptions;
using DigitalWallet.Application.UseCases.Transfer.Commands.CreateTransfer;
using DigitalWallet.Application.UseCases.Transfer.Queries;
using DigitalWallet.Web.DTOs.Inserts;
using DigitalWallet.Web.DTOs.Responses;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using TransferSimpleApplicationDTO = DigitalWallet.Application.UseCases.DTOs.TransferSimpleDTO;
using System.Security.Claims;

namespace DigitalWallet.Web.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TransferController : ControllerBase
    {
        private readonly CreateTransferHandler _createTransferHandler;
        private readonly GetSentTransfersHandler _getSentTransfersHandler;

        public TransferController(CreateTransferHandler createTransferHandler, GetSentTransfersHandler getSentTransfersHandler)
        {
            _createTransferHandler = createTransferHandler;
            _getSentTransfersHandler = getSentTransfersHandler;
        }

        [Authorize]
        [HttpPost]
        public async Task<ActionResult<TransferSimpleDTO>> CreateTransferAsync([FromBody] TransferInsertDTO dto)
        {
            try
            {
                Guid userIdAuthenticated = FindUserIdAuthenticated();
                var command = new CreateTransferCommand(userIdAuthenticated, dto.ReceiverId, dto.Amount);
                var response = await _createTransferHandler.HandleAsync(command);

                TransferSimpleDTO transfer = CreateResponseDTO(response);

                return Created(string.Empty, transfer);
            }
            catch (CreateEntityException e)
            {
                return BadRequest(e.Message);
            }
            catch (UnauthorizedAccessException e)
            {
                return Unauthorized(e.Message);
            }
        }

        [Authorize]
        [HttpGet("sent")]
        public async Task<ActionResult<List<TransferSimpleDTO>>> GetSentTransfers(
            [FromQuery] DateTime minDate,
            [FromQuery] DateTime maxDate,
            [FromQuery] int page,
            [FromQuery] int pageSize)
        {
            try
            {
                Guid userIdAuthenticated = FindUserIdAuthenticated();

                var query = new GetSentTransfersQuery(userIdAuthenticated, minDate, maxDate, page, pageSize);
                var response = await _getSentTransfersHandler.HandleAsync(query);

                return Ok(response.Select(CreateResponseDTO).ToList());
            }
            catch (UnauthorizedAccessException e)
            {
                return Unauthorized(e.Message);
            }
        }

        private Guid FindUserIdAuthenticated()
        {
            string userId = HttpContext.User.FindFirstValue(ClaimTypes.NameIdentifier);

            if (string.IsNullOrEmpty(userId) || !Guid.TryParse(userId, out var userGuid))
                throw new UnauthorizedAccessException("Erro: Token inválido!");

            return userGuid;
        }

        private TransferSimpleDTO CreateResponseDTO(TransferSimpleApplicationDTO response)
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