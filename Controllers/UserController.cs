using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Threading.Tasks;
using ToDoApp.Models;

[Route("api/[controller]")]
[ApiController]
public class UsersController : ControllerBase
{

    public UsersController(ApplicationDbContext context)
    {
        _context = context;
    }

    // Endpoint para obtener todos los usuarios
    [HttpGet]
    public async Task<ActionResult<IEnumerable<User>>> GetUsers()
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
