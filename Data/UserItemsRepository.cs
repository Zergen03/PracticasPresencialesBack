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

    public async Task<IEnumerable<UserItem>> GetUserItems()
    {
        try
        {
            return await _context.USERITEM
                .Include(x => x.User)
                .Include(x => x.Item)
                .ToListAsync();
        }
        catch (Exception ex)
        {
            throw new Exception($"Error getting user items: {ex.Message}");
        }
    }

    public async Task<IEnumerable<UserItem>> GetUserItem(int userId, int? itemId = null)
    {
        try
        {
            IQueryable<UserItem> query = _context.USERITEM
                .Include(ui => ui.User)
                .Include(ui => ui.Item)
                .Where(ui => ui.UserId == userId);

            if (itemId.HasValue)
            {
                query = query.Where(ui => ui.ItemId == itemId.Value);
            }
            return await query.ToListAsync();
        }
        catch (Exception ex)
        {
            throw new Exception($"Error getting user item: {ex.Message}");
        }
    }


    public async Task<UserItem> CreateUserItem(UserItem userItem)
    {
        try
        {
            var exist = await _context.USERITEM
                .AnyAsync(x =>
                    x.UserId == userItem.UserId &&
                    x.ItemId == userItem.ItemId);
            if (exist)
            {
                throw new Exception("User item already exists");
            }

            await _context.USERITEM.AddAsync(userItem);
            return userItem;
        }
        catch (Exception ex)
        {
            throw new Exception($"Error creating user item: {ex.Message}");
        }
    }

    public async Task DeleteUserItem(int userId, int? itemId)
    {
        try
        {
            IQueryable<UserItem> query = _context.USERITEM.Where(ui => ui.UserId == userId);

            if (itemId.HasValue)
            {
                query = query.Where(ui => ui.ItemId == itemId.Value);
            }

            List<UserItem> itemsToDelete = await query.ToListAsync();

            if (itemsToDelete.Count == 0)
            {
                return;
            }

            _context.USERITEM.RemoveRange(itemsToDelete);
        }
        catch (Exception ex)
        {
            throw new Exception($"Error deleting user item(s): {ex.Message}", ex);
        }
    }


    public async Task SaveChangesAsync()
    {
        await _context.SaveChangesAsync();
    }
}