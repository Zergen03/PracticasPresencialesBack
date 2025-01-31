using ToDoApp.Models;
using ToDoApp.Data;

namespace ToDoApp.Services;

public interface ICategoryService
{
    Task<IEnumerable<Category>> GetCategories();
    Task<Category> GetCategory(int id);
    Task<Category> CreateCategory(Category category);
    Task<Category> UpdateCategory(int id, Category category);
    Task DeleteCategory(int id);
}