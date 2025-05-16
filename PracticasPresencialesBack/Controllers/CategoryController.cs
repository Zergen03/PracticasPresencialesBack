using Microsoft.AspNetCore.Mvc;
using ToDoApp.DTOs.Categories;
using ToDoApp.Models;
using ToDoApp.Services;
using Microsoft.AspNetCore.Authorization;
using ToDoApp.Services.Interfaces;

namespace ToDoApp.Controllers;

[Route("api/[controller]")]
[ApiController]
public class CategoryController : ControllerBase
{
    private readonly ICategoryService _categoryService;
    private readonly IUserService _authService;
    public CategoryController(ICategoryService categoryService, IUserService authService)
    {
        _authService = authService;
        _categoryService = categoryService;
    }

    // Endpoint para obtener todas las categorías
    [Authorize (Roles = "admin")]
    [HttpGet]
    public async Task<ActionResult<IEnumerable<CategoryDTO>>> GetCategories()
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
    [Authorize]
    [HttpGet("{id}")]
    public async Task<ActionResult<CategoryDTO>> GetCategory(int id)
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

    // Endpoint para obtener categorías por id de usuario
    [Authorize]
    [HttpGet("user/{userId}")]
    public async Task<ActionResult<IEnumerable<CategoryDTO>>> GetCategoriesByUser(int userId)
    {
        try
        {

            if (!_authService.HasAccessToResource(userId, User))
            {
                return Forbid();
            }
            var categories = await _categoryService.GetCategoriesByUser(userId);
            return Ok(categories);
        }
        catch (Exception ex)
        {
            return BadRequest(ex.Message);
        }
    }

    // Endpoint para crear una categoría
    [Authorize]
    [HttpPost]
    public async Task<ActionResult<CategoryDTO>> PostCategory(CreateCategoryDTO category)
    {
        try
        {
            var newCategory = await _categoryService.CreateCategory(category);
            return CreatedAtAction("GetCategory", new { id = newCategory.User_Id }, newCategory);
        }
        catch (Exception ex)
        {
            return BadRequest(ex.Message);
        }
    }

    // Endpoint para actualizar una categoría
    [Authorize]
    [HttpPut("{id}")]
    public async Task<ActionResult<CategoryDTO>> PutCategory(int id, UpdateCategoryDTO category)
    {
        try
        {
            var getCategory = await _categoryService.GetCategory(id);
            var userId = getCategory.User_Id;
            var categoryReciever = category.User_Id;

            if (!_authService.HasAccessToResource(userId, User))
                return Forbid();

            if (!(User.IsInRole("admin")))
            {
                if (userId != categoryReciever)
                {
                    return BadRequest($"UserId from token: {userId} and UserId from body: {categoryReciever} are different");
                }
            }

            var updatedCategory = await _categoryService.UpdateCategory(id, category);
            return Ok(updatedCategory);
        }
        catch (Exception ex)
        {
            return BadRequest(ex.Message);
        }
    }

    // Endpoint para eliminar una categoría
    [Authorize]
    [HttpDelete("{id}")]
    public async Task<ActionResult> DeleteCategory(int id)
    {
        try
        {
            var category = await _categoryService.GetCategory(id);
            var userId = category.User_Id;

            if (!_authService.HasAccessToResource(userId, User))
                return Forbid();

            await _categoryService.DeleteCategory(id);
            return Ok();
        }
        catch (Exception ex)
        {
            return BadRequest(ex.Message);
        }
    }
}