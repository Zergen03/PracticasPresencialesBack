using ToDoApp.Models;
using ToDoApp.DTOs;

namespace ToDoApp.Services;

public interface IUserService
{
    Task<IEnumerable<User>> GetUsers();
    Task<User> GetUser(int id);
    Task<User> GetUser(string name);
    Task<User> Login(string _name, string _password);
    Task<User> CreateUser(UserDTO user);
    Task<User> UpdateUser(User user);
    Task DeleteUser(int id);
}