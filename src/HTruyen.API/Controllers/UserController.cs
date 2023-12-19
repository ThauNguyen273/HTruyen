using Core.DTOs.Chapters;
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
    private readonly UserViewService _userViewService;
    private readonly UserFollowService _userFollowService;
    private readonly UserFavoriteService _userFavoriteService;
    private readonly UserFeedbackService _userFeedbackService;

    public UserController(
        UserService userService, 
        UserViewService userViewService, 
        UserFollowService userFollowService, 
        UserFavoriteService userFavoriteService, 
        UserFeedbackService userFeedbackService)
    {
        _userService = userService;
        _userViewService = userViewService;
        _userFollowService = userFollowService;
        _userFavoriteService = userFavoriteService;
        _userFeedbackService = userFeedbackService;
    }

    #region User

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

    #endregion

    #region UserView

    [HttpGet("views")]
    public async Task<IEnumerable<UserViewShort>> GetViewAsync(
        [FromQuery] string? search = null,
        [FromQuery] ushort pageNumber = 1,
        [FromQuery] ushort pageSize = 15,
        [FromQuery] bool isDescending = false)
    {
        return await _userViewService.SearchAsync(search, pageNumber, pageSize, isDescending);
    }

    [HttpGet("view/{id}")]
    public async Task<ActionResult<UserView?>> GetViewById(string id)
    {
        var view = await _userViewService.GetAsync(id);
        if (view is null)
        {
            return NotFound();
        }

        return Ok(view);
    }

    [HttpPost("create-view")]
    public async Task<IActionResult> CreateViewAsync([FromBody] UserViewCreateUpdate body)
    {
        var newId = await _userViewService.CreateAsync(body);

        return CreatedAtAction(nameof(GetViewById), new { id = newId }, null);
    }

    [HttpPut("edit-view/{id}")]
    public async Task<IActionResult> EditViewAsync(string id, [FromBody] UserViewCreateUpdate body)
    {
        try
        {
            await _userViewService.ReplaceAsync(id, body);
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

    [HttpDelete("delete-view/{id}")]
    public async Task<IActionResult> DeleteViewAsync(string id)
    {
        try
        {
            await _userViewService.DeleteAsync(id);
        }
        catch (KeyNotFoundException)
        {
            return NotFound();
        }

        return NoContent();
    }

    #endregion

    #region UserFollow

    [HttpGet("follows")]
    public async Task<IEnumerable<UserFollowShort>> GetFollowAsync(
        [FromQuery] string? search = null,
        [FromQuery] ushort pageNumber = 1,
        [FromQuery] ushort pageSize = 15,
        [FromQuery] bool isDescending = false)
    {
        return await _userFollowService.SearchAsync(search, pageNumber, pageSize, isDescending);
    }

    [HttpGet("follow/{id}")]
    public async Task<ActionResult<UserFollow?>> GetFollowById(string id)
    {
        var follow = await _userFollowService.GetAsync(id);
        if (follow is null)
        {
            return NotFound();
        }

        return Ok(follow);
    }

    [HttpPost("create-follow")]
    public async Task<IActionResult> CreateFollowAsync([FromBody] UserFollowCreate body)
    {
        var newId = await _userFollowService.CreateAsync(body);

        return CreatedAtAction(nameof(GetFollowById), new { id = newId }, null);
    }

    [HttpDelete("delete-follow/{id}")]
    public async Task<IActionResult> DeleteFollowAsync(string id)
    {
        try
        {
            await _userFollowService.DeleteAsync(id);
        }
        catch (KeyNotFoundException)
        {
            return NotFound();
        }

        return NoContent();
    }

    #endregion

    #region UserFavorite

    [HttpGet("favorites")]
    public async Task<IEnumerable<UserFavoriteShort>> GetFavoriteAsync(
        [FromQuery] string? search = null,
        [FromQuery] ushort pageNumber = 1,
        [FromQuery] ushort pageSize = 15,
        [FromQuery] bool isDescending = false)
    {
        return await _userFavoriteService.SearchAsync(search, pageNumber, pageSize, isDescending);
    }

    [HttpGet("favorite/{id}")]
    public async Task<ActionResult<UserFavorite?>> GetFavoriteById(string id)
    {
        var favorite = await _userFavoriteService.GetAsync(id);
        if (favorite is null)
        {
            return NotFound();
        }

        return Ok(favorite);
    }

    [HttpPost("create-favorite")]
    public async Task<IActionResult> CreateFavoriteAsync([FromBody] UserFavoriteCreate body)
    {
        var newId = await _userFavoriteService.CreateAsync(body);

        return CreatedAtAction(nameof(GetFollowById), new { id = newId }, null);
    }

    [HttpDelete("delete-favorite/{id}")]
    public async Task<IActionResult> DeleteFavoriteAsync(string id)
    {
        try
        {
            await _userFavoriteService.DeleteAsync(id);
        }
        catch (KeyNotFoundException)
        {
            return NotFound();
        }

        return NoContent();
    }

    #endregion

    #region UserFeedback

    [HttpGet("feedbacks")]
    public async Task<IEnumerable<UserFeedbackShort>> GetFeedbackAsync(
        [FromQuery] string? search = null,
        [FromQuery] ushort pageNumber = 1,
        [FromQuery] ushort pageSize = 15,
        [FromQuery] bool isDescending = false)
    {
        return await _userFeedbackService.SearchAsync(search, pageNumber, pageSize, isDescending);
    }

    [HttpGet("feedback/{id}")]
    public async Task<ActionResult<UserFeedback?>> GetFeedbackById(string id)
    {
        var feedback = await _userFeedbackService.GetAsync(id);
        if (feedback is null)
        {
            return NotFound();
        }

        return Ok(feedback);
    }

    [HttpPost("create-feedback")]
    public async Task<IActionResult> CreateFeedbackAsync([FromBody] UserFeedbackCreate body)
    {
        var newId = await _userFeedbackService.CreateAsync(body);

        return CreatedAtAction(nameof(GetFeedbackById), new { id = newId }, null);
    }

    [HttpDelete("delete-feedback/{id}")]
    public async Task<IActionResult> DeleteFeedbackAsync(string id)
    {
        try
        {
            await _userFeedbackService.DeleteAsync(id);
        }
        catch (KeyNotFoundException)
        {
            return NotFound();
        }

        return NoContent();
    }

    #endregion
}
