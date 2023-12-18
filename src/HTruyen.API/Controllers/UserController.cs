using Core.DTOs.Users;
using Core.Entities;
using Core.Services;
using Microsoft.AspNetCore.Mvc;

namespace HTruyen.API.Controllers;

[Route("api/")]
[ApiController]
public class UserController : ControllerBase
{
    private readonly UserService _userService;

    public UserController(UserService userService)
    {
        _userService = userService;
    }

    [HttpGet("users")]
    public async Task<IEnumerable<UserShort>> GetUsersAsync(
        [FromQuery] string? search = null,
        [FromQuery] ushort pageNumber = 1,
        [FromQuery] ushort pageSize = 15,
        [FromQuery] bool isDescending = false)
    {
        return await _userService.SearchAsync(search, pageNumber, pageSize, isDescending);
    }

    [HttpGet("user/{id}")]
    public async Task<ActionResult<User?>> GetUserById(string id)
    {
        var user = await _userService.GetAsync(id);
        if (user is null)
        {
            return NotFound();
        }

        return Ok(user);
    }

    [HttpPost("created-User")]
    public async Task<IActionResult> CreateUserAsync([FromBody] UserCreateUpdate body)
    {
        var newId = await _userService.CreateAsync(body);
        return CreatedAtAction(nameof(GetUserById), new { id = newId }, null);

    }

    [HttpPut("edit-user/{id}")]
    public async Task<IActionResult> EditUserAsync(string id, [FromBody] UserCreateUpdate body)
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

    [HttpDelete("delete-user/id")]
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
