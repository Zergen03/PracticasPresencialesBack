using Microsoft.EntityFrameworkCore;
using ToDoApp.Models;

namespace ToDoApp.Data;

public class UserRepository : IUserRepository
{
    private readonly QuestifyContext _context;

    public UserRepository(QuestifyContext context)
    {
        _context = context;
    }

    public async Task<IEnumerable<User>> GetUsers()
    {
        try
        {
            return await _context.USERS.ToListAsync();
        }
        catch (Exception ex)
        {
            throw new Exception($"Error getting users: {ex.Message}");
        }
    }
    public async Task<User> GetUser(int id)
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

    public async Task<User> GetUser(string name)
    {
        try
        {
            return await _context.USERS.FirstOrDefaultAsync(u => u.Name == name);
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
            _context.USERS.Remove(user);
            await _context.SaveChangesAsync();
        }
        catch (Exception ex)
        {
            throw new Exception($"Error deleting user: {ex.Message}");
        }
    }

}
