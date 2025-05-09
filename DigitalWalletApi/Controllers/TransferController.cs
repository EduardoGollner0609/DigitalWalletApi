using DigitalWalletApi.DTOs.Entities;
using DigitalWalletApi.DTOs.ExceptionsRepresentation;
using DigitalWalletApi.Services;
using DigitalWalletApi.Services.Exceptions;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace DigitalWalletApi.Controllers
{
    [Route("v1/[controller]")]
    [ApiController]
    public class TransferController : ControllerBase
    {
        private readonly WalletService _walletService;
        private readonly UserService _userService;

        public TransferController(WalletService walletService, UserService userService)
        {
            _walletService = walletService;
            _userService = userService;
        }

        [Authorize]
        [HttpPost]
        public async Task<ActionResult<TransferDTO>> CreateAsync(TransferMinDTO dto)
        {
            try
            {
                UserAuthenticatedDTO user = await _userService.GetMe();
                dto.SetSenderId(user.Id);
                TransferDTO newDTO = await _walletService.ExecuteTransfer(dto);
                string uri = $"/transfer/{dto.Id}";
                return Created(uri, newDTO);
            }
            catch (CreateEntityException e)
            {
                return BadRequest(new ErrorResponseDTO(400, e.Message));
            }
        }
    }
}
