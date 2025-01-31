using ToDoApp.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace ToDoApp.Data
{
    public interface IUserRepository
    {
        Task<IEnumerable<User>> GetUsers();
        Task<User> GetUser(int id);
        Task<User> GetUser(string name);
        Task<User> CreateUser(User user);
        Task<User> UpdateUser(User user);
        Task DeleteUser(int id);
    }
}