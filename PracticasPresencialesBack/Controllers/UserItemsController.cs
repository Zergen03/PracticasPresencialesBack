using Microsoft.AspNetCore.Mvc;
using ToDoApp.Models;
using ToDoApp.Services;
using ToDoApp.DTOs.UserItems;

namespace ToDoApp.Controllers;

[Route("api/[controller]")]
[ApiController]
public class UserItemsController : ControllerBase
{
    private readonly IUserItemsService _userItemsService;
    public UserItemsController(IUserItemsService userItemsService)
    {
        _userItemsService = userItemsService;
    }

    // Endpoint para obtener todos los items de usuario
    [HttpGet]
    public async Task<ActionResult<IEnumerable<UserItemDTO>>> GetUserItems()
    {
        try
        {
            var userItems = await _userItemsService.GetUserItems();
            return Ok(userItems);
        }
        catch (Exception ex)
        {
            return BadRequest(ex.Message);
        }
    }

    // Endpoint para obtener todos los items de un usuario
    [HttpGet("{userId}")]
    public async Task<ActionResult<IEnumerable<UserItemDTO>>> GetUserItem(int userId, [FromQuery] int? itemId)
    {
        try
        {
            var userItems = await _userItemsService.GetUserItem(userId, itemId);
            return Ok(userItems);
        }
        catch (Exception ex)
        {
            return BadRequest(ex.Message);
        }
    }

    // Endpoint para crear un item de usuario
    [HttpPost]
    public async Task<ActionResult<UserItemDTO>> PostUserItem(CreateUserItemDTO userItem)
    {
        try
        {
            var newUserItem = await _userItemsService.CreateUserItem(userItem);
            return Ok(newUserItem);
        }
        catch (Exception ex)
        {
            return BadRequest(ex.Message);
        }
    }

    // Endpoint para eliminar un item de usuario
    [HttpDelete("{userId}")]
    public async Task<ActionResult> DeleteUserItem(int userId, [FromQuery] int? itemId)
    {
        try
        {
            await _userItemsService.DeleteUserItem(userId, itemId);
            return Ok();
        }
        catch (Exception ex)
        {
            return BadRequest(ex.Message);
        }
    }
}