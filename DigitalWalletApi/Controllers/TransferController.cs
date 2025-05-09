using DigitalWalletApi.DTOs.Entities;
using DigitalWalletApi.Services;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace DigitalWalletApi.Controllers
{
    [Route("v1/[controller]")]
    [ApiController]
    public class TransferController : ControllerBase
    {
        private readonly TransferService _transferService;

        public TransferController(TransferService transferService)
        {
            _transferService = transferService;
        }

        [Authorize]
        [HttpPost]
        public async Task<ActionResult<TransferDTO>> CreateAsync(TransferDTO transferDTO)
        {
            transferDTO = await _transferService.CreateAsync(transferDTO);
            string uri = $"/transfer/{transferDTO.Id}";
            return Created(uri, transferDTO);
        }
    }
}
