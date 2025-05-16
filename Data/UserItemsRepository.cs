using Microsoft.EntityFrameworkCore;
using ToDoApp.Models;

namespace ToDoApp.Data;

public class UserItemsRepository : IUserItemsRepository
{
    private readonly QuestifyContext _context;

    public UserItemsRepository(QuestifyContext context)
    {
        _context = context;
    }

    public async Task<IEnumerable<UserItems>> GetUserItems()
    {
        try
        {
            return await _context.USERITEMS.ToListAsync();
        }
        catch (Exception ex)
        {
            throw new Exception($"Error getting user items: {ex.Message}");
        }
    }

    public async Task<UserItems> GetUserItem(int id)
    {
        try
        {
            return await _context.USERITEMS.FindAsync(id);
        }
        catch (Exception ex)
        {
            throw new Exception($"Error getting user item: {ex.Message}");
        }
    }

    public async Task<IEnumerable<UserItems>> GetUserItems(int user_id)
    {
        try
        {
            return await _context.USERITEMS.Where(x => x.User_Id == user_id).ToListAsync();
        }
        catch (Exception ex)
        {
            throw new Exception($"Error getting user items: {ex.Message}");
        }
    }

    public async Task<IEnumerable<UserItems>> GetItemsUser(int item_id)
    {
        try
        {
            return await _context.USERITEMS.Where(x => x.Item_Id == item_id).ToListAsync();
        }
        catch (Exception ex)
        {
            throw new Exception($"Error getting user items: {ex.Message}");
        }
    }

    public async Task<UserItems> CreateUserItem(UserItems userItem)
    {
        try
        {
            _context.USERITEMS.Add(userItem);
            await _context.SaveChangesAsync();
            return userItem;
        }
        catch (Exception ex)
        {
            throw new Exception($"Error creating user item: {ex.Message}");
        }
    }

    public async Task<UserItems> UpdateUserItem(UserItems userItem)
    {
        try
        {
            _context.Entry(userItem).State = EntityState.Modified;
            await _context.SaveChangesAsync();
            return userItem;
        }
        catch (Exception ex)
        {
            throw new Exception($"Error updating user item: {ex.Message}");
        }
    }

    public async Task DeleteUserItem(int id)
    {
        try
        {
            var userItem = await _context.USERITEMS.FindAsync(id);
            _context.USERITEMS.Remove(userItem);
            await _context.SaveChangesAsync();
        }
        catch (Exception ex)
        {
            throw new Exception($"Error deleting user item: {ex.Message}");
        }
    }
}