using ToDoApp.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace ToDoApp.Data.Interfaces
{
    public interface IUserRepository
    {
        Task<IEnumerable<User>> GetUsers(string? name);
        Task<User?> GetUser(int id);
        Task<User> CreateUser(User user);
        Task<User> UpdateUser(User user);
        Task DeleteUser(int id);
        Task SaveChangesAsync();

    }
}