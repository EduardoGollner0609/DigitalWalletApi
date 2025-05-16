using DigitalWallet.Application.UseCases.DTOs.Abstractions;
using DigitalWallet.Application.UseCases.Exceptions;
using DigitalWallet.Application.UseCases.Wallet.Commands.Deposit;
using DigitalWallet.Application.UseCases.Wallet.Queries.GetBalance;
using DigitalWallet.Web.DTOs.Inserts;
using DigitalWallet.Web.DTOs.Responses;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Security.Claims;

namespace DigitalWallet.Web.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class WalletController : ControllerBase
    {
        private readonly GetBalanceHandler _getBalanceHandler;
        private readonly DepositHandler _depositHandler;

        public WalletController(GetBalanceHandler getBalanceHandler, DepositHandler depositHandler)
        {
            _getBalanceHandler = getBalanceHandler;
            _depositHandler = depositHandler;
        }

        [Authorize]
        [HttpGet("balance")]
        public async Task<ActionResult<UserWithBalanceDTO>> GetBalanceAsync()
        {
            try
            {
                Guid userIdAuthenticated = FindUserIdAuthenticated();

                var query = new GetBalanceQuery(userIdAuthenticated);
                var response = await _getBalanceHandler.HandleAsync(query);

                UserWithBalanceDTO userWithBalance = CreateUserWithBalanceDTO(response);

                return Ok(userWithBalance);
            }
            catch (UnauthorizedAccessException e)
            {
                return Unauthorized(new ErrorResponseDTO(401, e.Message, DateTime.Now));
            }
        }

        [Authorize]
        [HttpPut("deposit")]
        public async Task<ActionResult<UserWithBalanceDTO>> DepositAsync([FromBody] DepositInsertDTO dto)
        {
            try
            {
                Guid userIdAuthenticated = FindUserIdAuthenticated();

                var command = new DepositCommand(userIdAuthenticated, dto.Amount);
                var response = await _depositHandler.HandleAsync(command);

                UserWithBalanceDTO userWithBalance = CreateUserWithBalanceDTO(response);

                return Ok(userWithBalance);

            }
            catch (UnauthorizedAccessException e)
            {
                return Unauthorized(new ErrorResponseDTO(400, e.Message, DateTime.Now));
            }
        }

        private Guid FindUserIdAuthenticated()
        {
            string userId = HttpContext.User.FindFirstValue(ClaimTypes.NameIdentifier);

            if (string.IsNullOrEmpty(userId) || !Guid.TryParse(userId, out var userGuid))
                throw new UnauthorizedAccessException("Erro: Token inválido!");

            return userGuid;
        }

        private UserWithBalanceDTO CreateUserWithBalanceDTO(WalletResponseDTO response)
        {
            return new UserWithBalanceDTO(
                    new UserSimpleDTO(
                        response.User.Id,
                        response.User.Name,
                        response.User.Email),
                    response.Balance);
        }
    }
}
