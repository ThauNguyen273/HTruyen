using Core.DTOs.Payments;
using Core.Entities;
using Core.Services;
using Microsoft.AspNetCore.Mvc;

namespace HTruyen.API.Controllers;
[Route("api/[controller]")]
[ApiController]
public class PaymentController : ControllerBase
{
    private readonly WalletService _walletService;

    public PaymentController(WalletService walletService)
    {
        _walletService = walletService;
    }

    [HttpGet]
    public async Task<IEnumerable<WalletShort>> Get(
        [FromQuery] ushort pageNumber = 1,
        [FromQuery] ushort pageSize = 15,
        [FromQuery] bool isDescending = false)
    {
        return await _walletService.SearchAsync(pageNumber, pageSize, isDescending);
    }

    [HttpGet("{id}")]
    public async Task<ActionResult<Wallet>> Get(string id)
    {
        var wallet = await _walletService.GetAsync(id);
        if (wallet is null)
        {
            return NotFound();
        }

        return Ok(wallet);
    }

    [HttpPost]
    public async Task<IActionResult> Post([FromBody] WalletCreateUpdate body)
    {
        var newId = await _walletService.CreateAsync(body);
        return CreatedAtAction(nameof(Get), new { id = newId }, null);
    }

    [HttpPut("{id}")]
    public async Task<IActionResult> Put(string id, [FromBody] WalletCreateUpdate body)
    {
        try
        {
            await _walletService.ReplaceAsync(id, body);
        }
        catch (KeyNotFoundException)
        {
            return NotFound();
        }
        catch (Exception)
        {
            return StatusCode(StatusCodes.Status500InternalServerError);
        }

        return NoContent();
    }

    [HttpDelete("{id}")]
    public async Task<IActionResult> Delete(string id)
    {
        try
        {
            await _walletService.DeleteAsync(id);
        }
        catch (KeyNotFoundException)
        {
            return NotFound();
        }

        return NoContent();
    }
}

