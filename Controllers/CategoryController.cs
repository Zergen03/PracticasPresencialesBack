using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Threading.Tasks;
using ToDoApp.Models;

[Route("api/[controller]")]
[ApiController]
public class CategoriesController : ControllerBase
{
    private readonly ApplicationDbContext _context;

    public CategoriesController(ApplicationDbContext context)
    {
        _context = context;
    }

    // Endpoint para obtener todas las categorías
    [HttpGet]
    public async Task<ActionResult<IEnumerable<Category>>> GetCategories()
    {
        return await _context.CATEGORIES.ToListAsync();
    }

    // Endpoint para obtener una categoría por ID
    [HttpGet("{id}")]
    public async Task<ActionResult<Category>> GetCategory(int id)
    {
        var category = await _context.CATEGORIES.FindAsync(id);

        if (category == null)
        {
            return NotFound();
        }

        return category;
    }

    // Endpoint para crear una categoría
    [HttpPost]
    public async Task<ActionResult<Category>> PostCategory(Category category)
    {
        _context.CATEGORIES.Add(category);
        await _context.SaveChangesAsync();

        return CreatedAtAction("GetCategory", new { id = category.Id }, category);
    }

    // Endpoint para actualizar una categoría
    [HttpPut("{id}")]
    public async Task<IActionResult> PutCategory(int id, Category category)
    {
        if (id != category.Id)
        {
            return BadRequest();
        }

        _context.Entry(category).State = EntityState.Modified;
        await _context.SaveChangesAsync();

        return NoContent();
    }

    // Endpoint para eliminar una categoría
    [HttpDelete("{id}")]
    public async Task<IActionResult> DeleteCategory(int id)
    {
        var category = await _context.CATEGORIES.FindAsync(id);
        if (category == null)
        {
            return NotFound();
        }

        _context.CATEGORIES.Remove(category);
        await _context.SaveChangesAsync();

        return NoContent();
    }
}
