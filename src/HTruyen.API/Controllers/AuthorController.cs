using Core.DTOs.AuthorRanks;
using Core.DTOs.Authors;
using Core.DTOs.Users;
using Core.Entities;
using Core.Services;
using Microsoft.AspNetCore.Mvc;

namespace HTruyen.API.Controllers;
[Route("api/")]
[ApiController]
public class AuthorController : ControllerBase
{
    private readonly AuthorService _authorService;
    private readonly RankService _rankService;

    public AuthorController(
        AuthorService authorService, 
        RankService rankService)
    {
        _authorService = authorService;
        _rankService = rankService;
    }

    #region Author

    [HttpGet("authors")]
    public async Task<IEnumerable<AuthorShort>> GetAuthorAsync(
        [FromQuery] string? search = null,
        [FromQuery] ushort pageNumber = 1,
        [FromQuery] ushort pageSize = 15,
        [FromQuery] bool isDescending = false)
    {
        return await _authorService.SearchAsync(search, pageNumber, pageSize, isDescending);
    }

    [HttpGet("author/{id}")]
    public async Task<ActionResult<Author?>> GetAuthorById(string id)
    {
        var user = await _authorService.GetAsync(id);
        if (user is null)
        {
            return NotFound();
        }

        return Ok(user);
    }

    [HttpPost("create-author")]
    public async Task<IActionResult> CreateAuthorAsync([FromBody] AuthorCreateUpdate body)
    {
        var newId = await _authorService.CreateAsync(body);

        return CreatedAtAction(nameof(GetAuthorById), new {id =  newId}, null);
    }

    [HttpPut("edit-author/{id}")]
    public async Task<IActionResult> EditAuthorAsync(string id, [FromBody] AuthorCreateUpdate body)
    {
        try
        {
            await _authorService.ReplaceAsync(id, body);
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

    [HttpDelete("delete-author/{id}")]
    public async Task<IActionResult> DeleteAuthorAsync(string id)
    {
        try
        {
            await _authorService.DeleteAsync(id);
        }
        catch (KeyNotFoundException)
        {
            return NotFound();
        }

        return NoContent();
    }

    #endregion

    #region Rank

    [HttpGet("ranks")]
    public async Task<IEnumerable<RankShort>> GetRankAsync(
        [FromQuery] string? search = null,
        [FromQuery] ushort pageNumber = 1,
        [FromQuery] ushort pageSize = 15,
        [FromQuery] bool isDescending = false)
    {
        return await _rankService.SearchAsync(search, pageNumber, pageSize, isDescending);
    }

    [HttpGet("rank/{id}")]
    public async Task<ActionResult<Rank>> GetRankById(string id)
    {
        var rank = await _rankService.GetAsync(id);
        if (rank is null)
        {
            return NotFound();
        }

        return Ok(rank);
    }

    [HttpPost("create-rank")]
    public async Task<IActionResult> CreateRankAsync([FromBody] RankCreateUpdate body)
    {
        var newId = await _rankService.CreateAsync(body);
        return CreatedAtAction(nameof(GetRankById), new { id = newId }, null);
    }

    [HttpPut("edit-rank/{id}")]
    public async Task<IActionResult> EditRankAsync(string id, [FromBody] RankCreateUpdate body)
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

    [HttpDelete("delete-rank/{id}")]
    public async Task<IActionResult> DeleteRankAsync(string id)
    {
        try
        {
            await _rankService.DeleteAsync(id);
        }
        catch (KeyNotFoundException)
        {
            return NotFound();
        }

        return NoContent();
    }

    #endregion
}
