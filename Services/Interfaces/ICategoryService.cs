using ToDoApp.Models;
using ToDoApp.Data;
using ToDoApp.DTOs.Categories;

namespace ToDoApp.Services;

public interface ICategoryService
{
    Task<IEnumerable<CategoryDTO>> GetCategories();
    Task<CategoryDTO> GetCategory(int id);
    Task<IEnumerable<CategoryDTO>> GetCategoriesByUser(int userId);
    Task<CategoryDTO> CreateCategory(CreateCategoryDTO category);
    Task<CategoryDTO> UpdateCategory(int id, UpdateCategoryDTO category);
    Task DeleteCategory(int id);
}