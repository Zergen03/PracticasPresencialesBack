using ToDoApp.Models;
using ToDoApp.Data;

namespace ToDoApp.Services;

public class CategoryService : ICategoryService
{
    private readonly ICategoryRepository _categoryRepository;

    public CategoryService(ICategoryRepository categoryRepository)
    {
        _categoryRepository = categoryRepository;
    }

    public async Task<IEnumerable<Category>> GetCategories()
    {
        try
        {
            return await _categoryRepository.GetCategories();
        }
        catch (Exception ex)
        {
            throw new ArgumentException($"Error getting categories: {ex.Message}");
        }
    }

    public async Task<Category> GetCategory(int id)
    {
        try
        {
            return await _categoryRepository.GetCategory(id);
        }
        catch (ArgumentException ex)
        {
            throw new ArgumentException($"Invalid category ID: {ex.Message}");
        }
        catch (Exception ex)
        {
            throw new ArgumentException($"Error getting category: {ex.Message}");
        }
    }

    public async Task<Category> CreateCategory(Category category)
    {
        try
        {
            return await _categoryRepository.CreateCategory(category);
        }
        catch (Exception ex)
        {
            throw new ArgumentException($"Error creating category: {ex.Message}");
        }
    }

    public async Task<Category> UpdateCategory(int id, Category category)
    {
        try
        {
            return await _categoryRepository.UpdateCategory(id, category);
        }
        catch (ArgumentException ex)
        {
            throw new ArgumentException($"Invalid category ID: {ex.Message}");
        }
        catch (Exception ex)
        {
            throw new ArgumentException($"Error updating category: {ex.Message}");
        }
    }

    public async Task DeleteCategory(int id)
    {
        try
        {
            await _categoryRepository.DeleteCategory(id);
        }
        catch (ArgumentException ex)
        {
            throw new ArgumentException($"Invalid category ID: {ex.Message}");
        }
        catch (Exception ex)
        {
            throw new ArgumentException($"Error deleting category: {ex.Message}");
        }
    }
}