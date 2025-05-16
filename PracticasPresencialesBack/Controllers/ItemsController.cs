using Microsoft.AspNetCore.Mvc;
using ToDoApp.Services;
using ToDoApp.DTOs.Items;
using Microsoft.AspNetCore.Authorization;
using ToDoApp.Services.Interfaces;

namespace ToDoApp.Controllers;

[ApiController]
[Route("api/[controller]")]
public class ItemsController : ControllerBase
{
    private readonly IItemsService _itemsService;
    private readonly IUserService _authService;
    public ItemsController(IItemsService itemsService, IUserService authService)
    {
        _authService = authService;
        _itemsService = itemsService;
    }

    [Authorize (Roles = "admin")]
    [HttpGet]
    public async Task<ActionResult<IEnumerable<ItemDTO>>> GetItems([FromQuery] string? name)
    {
        try
        {
            var items = await _itemsService.GetAllItems(name);
            return Ok(items);
        }
        catch (Exception ex)
        {
            return BadRequest(ex.Message);
        }
    }

    [Authorize]
    [HttpGet("{id}")]
    public async Task<ActionResult<ItemDTO>> GetItem(int id)
    {
        try
        {
            var item = await _itemsService.GetItemById(id);
            return Ok(item);
        }
        catch (Exception ex)
        {
            return BadRequest(ex.Message);
        }
    }

    [Authorize (Roles = "admin")]
    [HttpPost]
    public async Task<ActionResult<ItemDTO>> PostItem([FromBody] CreateItemDTO item)
    {
        try
        {
            await _itemsService.AddItem(item);
            return Ok();
        }
        catch (Exception ex)
        {
            return BadRequest(ex.Message);
        }
    }

    [Authorize (Roles = "admin")]
    [HttpPut]
    public async Task<ActionResult<ItemDTO>> PutItem(int id, UpdateItemDTO item)
    {
        try
        {
            var updatedItem = await _itemsService.UpdateItem(id, item);
            return Ok(updatedItem);
        }
        catch (Exception ex)
        {
            return BadRequest(ex.Message);
        }
    }

    [Authorize (Roles = "admin")]
    [HttpDelete("{id}")]
    public async Task<ActionResult<ItemDTO>> DeleteItem(int id)
    {
        try
        {
            await _itemsService.DeleteItem(id);
            return Ok();
        }
        catch (Exception ex)
        {
            return BadRequest(ex.Message);
        }
    }
}
