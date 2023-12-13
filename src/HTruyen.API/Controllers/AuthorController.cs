using Core.DTOs.AuthorRanks;
using Core.DTOs.Authors;
using Core.DTOs.Users;
using Core.Entities;
using Core.Services;
using Microsoft.AspNetCore.Mvc;

namespace HTruyen.API.Controllers;
[Route("api/[controller]")]
[ApiController]
public class AuthorController : ControllerBase
{
    private readonly AuthorService _authorService;
    private readonly RankService _rankService;

    public AuthorController(AuthorService authorService, RankService rankService)
    {
        _authorService = authorService;
        _rankService = rankService;
    }

    #region Author

    [HttpGet]
    public async Task<IEnumerable<AuthorShort>> Get(
        [FromQuery] string? search = null,
        [FromQuery] ushort pageNumber = 1,
        [FromQuery] ushort pageSize = 15,
        [FromQuery] bool isDescending = false)
    {
        return await _authorService.SearchAsync(search, pageNumber, pageSize, isDescending);
    }

    [HttpGet("{id}")]
    public async Task<ActionResult<Author?>> Get(string id)
    {
        var user = await _authorService.GetAsync(id);
        if (user is null)
        {
            return NotFound();
        }

        return Ok(user);
    }

    [HttpPost]
    public async Task<IActionResult> Post([FromBody] AuthorCreateUpdate body)
    {
        var newId = await _authorService.CreateAsync(body);

        return CreatedAtAction(nameof(Get), new {id =  newId}, null);
    }

    [HttpPut("{id}")]
    public async Task<IActionResult> Put(string id, [FromBody] AuthorCreateUpdate body)
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

    [HttpDelete("{id}")]
    public async Task<IActionResult> Delete(string id)
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
    public async Task<IEnumerable<Rank>> GetAllRanks()
    {
        return await _authorService.GetAllRanks();
    }

    #endregion
}
