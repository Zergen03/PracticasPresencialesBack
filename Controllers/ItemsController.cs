using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using ToDoApp.Models;

[Route("api/[controller]")]
[ApiController]
public class ItemsController : ControllerBase
{
    private readonly ApplicationDbContext _context;

    public ItemsController(ItemsService service)
    {
        _service = service;
    }

    [HttpGet]
    public async Task<IActionResult> GetItem(int itemId)
    {
        var item = await _context.GetItem()

        return Ok(users);
    }

    [HttpGet]
    public async Task<IActionResult> GetUsers()
    {
        return await _context.USERS.ToListAsync();
    }

    // Endpoint para obtener un usuario por ID
    [HttpGet("{id}")]
    public async Task<ActionResult<User>> GetUser(int id)
    {
        var user = await _context.USERS.FindAsync(id);

        if (user == null)
        {
            return NotFound();
        }

        return user;
    }

    // Endpoint para crear un usuario
    [HttpPost]
    public async Task<ActionResult<User>> PostUser(User user)
    {
        _context.USERS.Add(user);
        await _context.SaveChangesAsync();

        return CreatedAtAction("GetUser", new { id = user.Id }, user);
    }
}
