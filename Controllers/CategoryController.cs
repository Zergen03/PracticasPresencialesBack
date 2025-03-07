using Microsoft.AspNetCore.Mvc;
using ToDoApp.Models;
using ToDoApp.Services;

namespace ToDoApp.Controllers;

[Route("api/[controller]")]
[ApiController]
public class CategoryController : ControllerBase
{
    private readonly ICategoryService _categoryService;
    public CategoryController(ICategoryService categoryService)
    {
        _categoryService = categoryService;
    }

    // Endpoint para obtener todas las categorías
    [HttpGet]
    public async Task<ActionResult<IEnumerable<Category>>> GetCategories()
    {
        try
        {
            var categories = await _categoryService.GetCategories();
            return Ok(categories);
        }
        catch (Exception ex)
        {
            return BadRequest(ex.Message);
        }
    }

    // Endpoint para obtener una categoría por ID
    [HttpGet("{id}")]
    public async Task<ActionResult<Category>> GetCategory(int id)
    {
        try
        {
            var category = await _categoryService.GetCategory(id);
            return Ok(category);
        }
        catch (Exception ex)
        {
            return BadRequest(ex.Message);
        }
    }

    // Endpoint para crear una categoría
    [HttpPost]
    public async Task<ActionResult<Category>> PostCategory(Category category)
    {
        try
        {
            var newCategory = await _categoryService.CreateCategory(category);
            return CreatedAtAction("GetCategory", new { id = newCategory.Id }, newCategory);
        }
        catch (Exception ex)
        {
            return BadRequest(ex.Message);
        }
    }

    // Endpoint para actualizar una categoría
    [HttpPut("{id}")]
    public async Task<ActionResult<Category>> PutCategory(int id, Category category)
    {
        try
        {
            var updatedCategory = await _categoryService.UpdateCategory(id, category);
            return Ok(updatedCategory);
        }
        catch (Exception ex)
        {
            return BadRequest(ex.Message);
        }
    }

    // Endpoint para eliminar una categoría
    [HttpDelete("{id}")]
    public async Task<ActionResult> DeleteCategory(int id)
    {
        try
        {
            await _categoryService.DeleteCategory(id);
            return Ok();
        }
        catch (Exception ex)
        {
            return BadRequest(ex.Message);
        }
    }
}