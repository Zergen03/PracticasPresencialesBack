using Microsoft.EntityFrameworkCore;
using ToDoApp.Models;

namespace ToDoApp.Data;

public class UserRepository : IUserRepository{
     private readonly ApplicationDbContext _context;

        public UserRepository(ApplicationDbContext context)
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
            return await _context.USERS.FindAsync(id);
        }

        public async Task<User> GetUser(string name)
        {
            return await _context.USERS.FirstOrDefaultAsync(u => u.Name == name);
        }

        public async Task<User> CreateUser(User user)
        {
            _context.USERS.Add(user);
            _context.SaveChangesAsync();
            return user;
        }

        public async Task<User> UpdateUser(User user)
        {
            _context.USERS.Update(user);
            _context.SaveChangesAsync();
            return user;
        }

        public async Task DeleteUser(int id)
        {
            var user = await _context.USERS.FindAsync(id);
                _context.USERS.Remove(user);
                await _context.SaveChangesAsync();
        }

} 
