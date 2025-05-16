using ToDoApp.Models;

namespace ToDoApp.Data
{
    public interface ICategoryRepository
    {
        Task<IEnumerable<Category>> GetCategories();
        Task<Category> GetCategory(int id);
        Task<IEnumerable<Category>> GetCategoriesByUser(int userId);
        Task<Category> CreateCategory(Category category);
        Task<Category> UpdateCategory(Category category);
        Task DeleteCategory(int id);
        Task SaveChangesAsync();
    }
}   