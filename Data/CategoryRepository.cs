using Microsoft.EntityFrameworkCore;
using ToDoApp.Models;

namespace ToDoApp.Data;

public class CategoryRepository : ICategoryRepository
{
    private readonly QuestifyContext _context;

    public CategoryRepository(QuestifyContext context)
    {
        _context = context;
    }

    public async Task<IEnumerable<Category>> GetCategories()
    {
        try
        {
            return await _context.CATEGORIES.ToListAsync();
        }
        catch (Exception ex)
        {
            throw new Exception($"Error getting categories: {ex.Message}");
        }
    }

    public async Task<Category> GetCategory(int id)
    {
        try
        {
            return await _context.CATEGORIES.FindAsync(id);
        }
        catch (Exception ex)
        {
            throw new Exception($"Error getting category: {ex.Message}");
        }
    }

    public async Task<IEnumerable<Category>> GetCategoriesByUser(int userId)
    {
        try
        {
            return await _context.CATEGORIES.Where(c => c.UserId == userId).ToListAsync();
        }
        catch (Exception ex)
        {
            throw new Exception($"Error getting categories by user: {ex.Message}");
        }
    }

    public async Task<Category> CreateCategory(Category category)
    {
        try
        {
            _context.CATEGORIES.Add(category);
            await _context.SaveChangesAsync();
            return category;
        }
        catch (Exception ex)
        {
            throw new Exception($"Error creating category: {ex.Message}");
        }
    }

    public async Task<Category> UpdateCategory(Category category)
    {
        try
        {
            _context.CATEGORIES.Update(category);
            await _context.SaveChangesAsync();
            return category;
        }
        catch (Exception ex)
        {
            throw new Exception($"Error updating category: {ex.Message}");
        }
    }

    public async Task DeleteCategory(int id)
    {
        try
        {
            var category = await _context.CATEGORIES.FindAsync(id);
            _context.CATEGORIES.Remove(category);
            await _context.SaveChangesAsync();
        }
        catch (Exception ex)
        {
            throw new Exception($"Error deleting category: {ex.Message}");
        }
    }

    public async Task SaveChangesAsync()
    {
        await _context.SaveChangesAsync();
    }

}