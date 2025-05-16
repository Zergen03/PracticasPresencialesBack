using Microsoft.AspNetCore.Mvc;
using ToDoApp.Models;
using ToDoApp.Services;

namespace ToDoApp.Controllers;

[ApiController]
[Route("api/[controller]")]
public class ItemsController : ControllerBase
{
    private readonly IItemsService _itemsService;
    public ItemsController(IItemsService itemsService)
    {
        _itemsService = itemsService;
    }

    [HttpGet]
    public async Task<ActionResult<IEnumerable<Items>>> GetItems()
    {
        try
        {
            var items = await _itemsService.GetAllItems();
            return Ok(items);
        }
        catch (Exception ex)
        {
            return BadRequest(ex.Message);
        }
    }

    [HttpGet("{id}")]
    public async Task<ActionResult<Items>> GetItem(int id)
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

    [HttpPost]
    public async Task<ActionResult<Items>> PostItem([FromBody] Items item)
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

    [HttpPut]
    public async Task<ActionResult<Items>> PutItem(int id, Items item)
    {
        if (id != item.Id)
        {
            return BadRequest("Item ID does not match");
        }
        try
        {
            var updatedItem = await _itemsService.UpdateItem(item);
            return Ok(updatedItem);
        }
        catch (Exception ex)
        {
            return BadRequest(ex.Message);
        }
    }

    [HttpDelete("{id}")]
    public async Task<ActionResult> DeleteItem(int id)
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
