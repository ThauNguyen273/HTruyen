using Core.DTOs.Users;
using Core.Entities;
using Core.Services;
using Microsoft.AspNetCore.Mvc;

namespace HTruyen.API.Controllers;

[Route("api/[controller]")]
[ApiController]
public class UserController : ControllerBase
{
    private readonly UserService _userService;

    public UserController(UserService userService)
    {
        _userService = userService;
    }

    [HttpGet]
    public async Task<IEnumerable<UserShort>> Get(
        [FromQuery] string? search = null,
        [FromQuery] ushort pageNumber = 1,
        [FromQuery] ushort pageSize = 15,
        [FromQuery] bool isDescending = false)
    {
        return await _userService.SearchAsync(search, pageNumber, pageSize, isDescending);
    }

    [HttpGet("{id}")]
    public async Task<ActionResult<User?>> Get(string id)
    {
        var user = await _userService.GetAsync(id);
        if (user is null)
        {
            return NotFound();
        }

        return Ok(user);
    }

    [HttpPost]
    public async Task<IActionResult> Post([FromBody] UserCreateUpdate body)
    {
        var newId = await _userService.CreateAsync(body);
        return CreatedAtAction(nameof(Get), new { id = newId }, null);

    }

    [HttpPut("{id}")]
    public async Task<IActionResult> Put(string id, [FromBody] UserCreateUpdate body)
    {
        try
        {
            await _userService.ReplaceAsync(id, body);
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
            await _userService.DeleteAsync(id);
        }
        catch (KeyNotFoundException)
        {
            return NotFound();
        }

        return NoContent() ;
    }
}
