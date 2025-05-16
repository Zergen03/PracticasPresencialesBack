using Microsoft.EntityFrameworkCore;
using ToDoApp.Models;
using ToDoApp.Data.Interfaces;

namespace ToDoApp.Data;

public class UserRepository : IUserRepository
{
    private readonly QuestifyContext _context;

    public UserRepository(QuestifyContext context)
    {
        _context = context;
    }

    public async Task<IEnumerable<User>> GetUsers(string? name)
    {
        try
        {
            var query = _context.USERS.AsQueryable();
            if (!string.IsNullOrWhiteSpace(name))
            {
                query = query.Where(u => u.Name.Contains(name)); 
            }
            return await query.ToListAsync();
        }
        catch (Exception ex)
        {
            throw new Exception($"Error getting users: {ex.Message}");
        }
    }

    public async Task<User?> GetUser(int id)
    {
        try
        {
            return await _context.USERS.FindAsync(id);
        }
        catch (Exception ex)
        {
            throw new Exception($"Error getting user: {ex.Message}");
        }
    }

    public async Task<User> CreateUser(User user)
    {
        try
        {
            _context.USERS.Add(user);
            await _context.SaveChangesAsync();
            return user;
        }
        catch (Exception ex)
        {
            throw new Exception($"Error creating user: {ex.Message}");
        }
    }

    public async Task<User> UpdateUser(User user)
    {
        try
        {
            _context.USERS.Update(user);
            await _context.SaveChangesAsync();
            return user;
        }
        catch (Exception ex)
        {
            throw new Exception($"Error updating user: {ex.Message}");
        }
    }

    public async Task DeleteUser(int id)
    {
        try
        {
            var user = await _context.USERS.FindAsync(id);
            if (user != null)
            {
                _context.USERS.Remove(user);
                await _context.SaveChangesAsync();
            }
        }
        catch (Exception ex)
        {
            throw new Exception($"Error deleting user: {ex.Message}");
        }
    }

    public async Task SaveChangesAsync()
    {
        await _context.SaveChangesAsync();
    }
}
