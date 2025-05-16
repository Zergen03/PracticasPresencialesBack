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
    [HttpGet("{user_id}")]
    public async Task<ActionResult<IEnumerable<UserItemDTO>>> GetUserItems(int user_id, int itemId)
    {
        try
        {
            var userItems = await _userItemsService.GetUserItems(user_id);
            return Ok(userItems);
        }
        catch (Exception ex)
        {
            return BadRequest(ex.Message);
        }
    }

    // Endpoint para obtener todos los usuarios de un item
    [HttpGet("item/{item_id}")]
    public async Task<ActionResult<IEnumerable<UserItems>>> GetItemsUser(int item_id)
    {
        try
        {
            var userItems = await _userItemsService.GetItemsUser(item_id);
            return Ok(userItems);
        }
        catch (Exception ex)
        {
            return BadRequest(ex.Message);
        }
    }

    // Endpoint para crear un item de usuario
    [HttpPost]
    public async Task<ActionResult<UserItems>> PostUserItem(UserItems userItem)
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

    // Endpoint para actualizar un item de usuario
    [HttpPut]
    public async Task<ActionResult<UserItems>> PutUserItem(UserItems userItem)
    {
        try
        {
            var updatedUserItem = await _userItemsService.UpdateUserItem(userItem);
            return Ok(updatedUserItem);
        }
        catch (Exception ex)
        {
            return BadRequest(ex.Message);
        }
    }

    // Endpoint para eliminar un item de usuario
    [HttpDelete("{id}")]
    public async Task<ActionResult> DeleteUserItem(int id)
    {
        try
        {
            await _userItemsService.DeleteUserItem(id);
            return Ok();
        }
        catch (Exception ex)
        {
            return BadRequest(ex.Message);
        }
    }
}