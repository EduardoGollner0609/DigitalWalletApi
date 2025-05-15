using DigitalWallet.Application.UseCases.Exceptions;
using DigitalWallet.Application.UseCases.Wallet.Commands.Deposit;
using DigitalWallet.Application.UseCases.Wallet.Queries.GetBalance;
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
        public async Task<ActionResult<UserWithBalanceDTO>> GetBalance()
        {
            try
            {
                Guid userIdAuthenticated = FindUserIdAuthenticated();

                var query = new GetBalanceQuery(userIdAuthenticated);
                var response = await _getBalanceHandler.HandleAsync(query);

                UserWithBalanceDTO userWithBalance = new UserWithBalanceDTO(
                    new UserSimpleDTO(
                        response.User.Id,
                        response.User.Name,
                        response.User.Email),
                    response.Balance);

                return Ok(userWithBalance);

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
    }
}
