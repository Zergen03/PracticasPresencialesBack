using Microsoft.EntityFrameworkCore;
using ToDoApp.Models;

namespace ToDoApp.Data;

public class ItemsRepository : IItemsRepository
{
    private readonly QuestifyContext _context;

    public ItemsRepository(QuestifyContext context)
    {
        _context = context;
    }

    public async Task<IEnumerable<Items>> GetAllItems(string? name)
    {
        try
        {
            return await _context.ITEMS.ToListAsync();
        }
        catch (Exception ex)
        {
            throw new Exception($"Error getting items: {ex.Message}");
        }
    }

    public async Task<Items> GetItemById(int id)
    {
        try
        {
            return await _context.ITEMS.FindAsync(id);
        }
        catch (Exception ex)
        {
            throw new Exception($"Error getting item: {ex.Message}");
        }
    }

    public async Task<Items> AddItem(Items item)
    {
        try
        {
            _context.ITEMS.Add(item);
            await _context.SaveChangesAsync();
            return item;
        }
        catch (Exception ex)
        {
            throw new Exception($"Error adding item: {ex.Message}");
        }
    }

    public async Task<Items> UpdateItem(Items item)
    {
        try
        {
            _context.Update(item);
            await _context.SaveChangesAsync();
            return item;
        }
        catch (Exception ex)
        {
            throw new Exception($"Error updating item: {ex.Message}");
        }
    }

    public async Task DeleteItem(int id)
    {
        try
        {
            var item = await _context.ITEMS.FindAsync(id);
            _context.ITEMS.Remove(item);
            await _context.SaveChangesAsync();
        }
        catch (Exception ex)
        {
            throw new Exception($"Error deleting item: {ex.Message}");
        }
    }

    public async Task SaveChangesAsync()
    {
        await _context.SaveChangesAsync();
    }
}