using Core.DTOs.AuthorRanks;
using Core.Entities;
using Core.Services;
using Microsoft.AspNetCore.Mvc;

namespace HTruyen.API.Controllers;

[Route("api/[controller]")]
[ApiController]
public class RankController : ControllerBase
{
    private readonly RankService _rankService;

    public RankController(RankService rankService)
    {
        _rankService = rankService;
    }

    [HttpGet]
    public async Task<IEnumerable<RankShort>> Get(
        [FromQuery] string? search = null,
        [FromQuery] ushort pageNumber = 1,
        [FromQuery] ushort pageSize = 15,
        [FromQuery] bool isDescending = false)
    {
        return await _rankService.SearchAsync(search, pageNumber, pageSize, isDescending);
    }

    [HttpGet("{id}")]
    public async Task<ActionResult<Rank>> Get(string id)
    {
        var rank = await _rankService.GetAsync(id);
        if (rank is null)
        {
            return NotFound();
        }

        return Ok(rank);
    }

    [HttpPost]
    public async Task<IActionResult> Post([FromBody] RankCreateUpdate body)
    {
        var newId = await _rankService.CreateAsync(body);
        return CreatedAtAction(nameof(Get), new {id = newId}, null);
    }

    [HttpPut("{id}")]
    public async Task<IActionResult> Put(string id, [FromBody] RankCreateUpdate body)
    {
        try
        {
            await _rankService.ReplaceAsync(id, body);
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

    [HttpDelete]
    public async Task<IActionResult> Delete(string id)
    {
        try
        {
            await _rankService.DeleteAsync(id);
        }
        catch (KeyNotFoundException)
        {
            return NotFound();
        }

        return NoContent() ;
    }
}

