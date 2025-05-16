using DigitalWallet.Application.UseCases.Exceptions;
using DigitalWallet.Application.UseCases.Transfer.Commands.CreateTransfer;
using DigitalWallet.Web.DTOs.Inserts;
using DigitalWallet.Web.DTOs.Responses;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using TransferSimpleApplicationDTO = DigitalWallet.Application.UseCases.DTOs.TransferSimpleDTO;
using System.Security.Claims;
using DigitalWallet.Application.UseCases.Transfer.Queries.GetSentTranfers;
using DigitalWallet.Application.UseCases.Transfer.Queries;

namespace DigitalWallet.Web.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TransferController : ControllerBase
    {
        private readonly CreateTransferHandler _createTransferHandler;
        private readonly GetSentTransfersHandler _getSentTransfersHandler;
        private readonly GetTransfersHandler _getTransfersHandler;

        public TransferController(CreateTransferHandler createTransferHandler, GetSentTransfersHandler getSentTransfersHandler, GetTransfersHandler getTransfersHandler)
        {
            _createTransferHandler = createTransferHandler;
            _getSentTransfersHandler = getSentTransfersHandler;
            _getTransfersHandler = getTransfersHandler;
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
                return BadRequest(new ErrorResponseDTO(400, e.Message, DateTime.Now));
            }
            catch (UnauthorizedAccessException e)
            {
                return Unauthorized(new ErrorResponseDTO(401, e.Message, DateTime.Now));
            }
        }

        [Authorize]
        [HttpGet("sent")]
        public async Task<ActionResult<List<TransferSimpleDTO>>> GetSentTransfers(
            [FromQuery] DateTime? minDate,
            [FromQuery] DateTime? maxDate,
            [FromQuery] int? page,
            [FromQuery] int? pageSize)
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
                return Unauthorized(new ErrorResponseDTO(401, e.Message, DateTime.Now));
            }
        }

        [Authorize]
        [HttpGet]
        public async Task<ActionResult<List<TransferSimpleDTO>>> GetTransfers(
          [FromQuery] DateTime? minDate,
          [FromQuery] DateTime? maxDate,
          [FromQuery] int? page,
          [FromQuery] int? pageSize)
        {
            try
            {
                Guid userIdAuthenticated = FindUserIdAuthenticated();

                var query = new GetTransfersQuery(userIdAuthenticated, minDate, maxDate, page, pageSize);
                var response = await _getTransfersHandler.HandleAsync(query);

                return Ok(response.Select(CreateResponseDTO).ToList());
            }
            catch (UnauthorizedAccessException e)
            {
                return Unauthorized(new ErrorResponseDTO(401, e.Message, DateTime.Now));
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