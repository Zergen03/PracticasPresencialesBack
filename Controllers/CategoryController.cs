using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Threading.Tasks;
using ToDoApp.Models;
using ToDoApp.Services;

[Route("api/[controller]")]
[ApiController]
public class CategoriesController : ControllerBase
{
    private readonly CategoryService _service;

    public CategoriesController(CategoryService categoryService)
    {
        _service = categoryService;
    }

    // Obtener todas las categorías
    [HttpGet]
    public async Task<ActionResult<IEnumerable<Category>>> GetAll()
    {
        try
        {
            var categories = await _service.GetAll();
            return Ok(categories);
        }
        catch (Exception ex)
        {
            return BadRequest($"Error: {ex.Message}");
        }
    }

    // Obtener una categoría por ID
    [HttpGet("{id}")]
    public async Task<ActionResult<Category>> GetById(int id)
    {
        var category = await _service.GetById(id);
        if (category == null)
        {
            return NotFound();
        }
        return Ok(category);
    }

    // Obtener una categoría por nombre
    [HttpGet("name/{name}")]
    public async Task<ActionResult<Category>> GetByName(string name)
    {
        var category = await _service.GetByName(name);
        if (category == null)
        {
            return NotFound();
        }
        return Ok(category);
    }

    // Crear una nueva categoría
    [HttpPost]
    public async Task<ActionResult<Category>> Insert(Category category)
    {
        var id = await _service.Insert(category);
        if (id == 0)
        {
            return BadRequest("No se pudo crear la categoría.");
        }
        return CreatedAtAction(nameof(GetById), new { id = category.Id }, category);
    }

    // Actualizar una categoría por ID
    [HttpPut("{id}")]
    public async Task<IActionResult> Update(int id, Category category)
    {
        if (id != category.Id)
        {
            return BadRequest("El ID proporcionado no coincide con la categoría.");
        }

        var result = await _service.Update(id);
        if (result == 0)
        {
            return NotFound();
        }

        return NoContent();
    }

    // Eliminar una categoría
    [HttpDelete("{id}")]
    public async Task<IActionResult> Delete(int id)
    {
        var category = await _service.GetById(id);
        if (category == null)
        {
            return NotFound();
        }

        await _service.Delete(category);
        return NoContent();
    }
}
