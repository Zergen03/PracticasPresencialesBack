using ToDoApp.Models;
using ToDoApp.DTOs.Users;
using System.Security.Claims;

namespace ToDoApp.Services.Interfaces;

public interface IUserService
{
    Task<IEnumerable<UserDTO>> GetUsers(string? name);
    Task<UserDTO> GetUser(int id);
    Task<UserDTO> Login(LoginDTO user);
    Task<UserDTO> CreateUser(CreateUserDTO user);
    Task<UserDTO> UpdateUser(int id, UpdateUserDTO user);
    Task DeleteUser(int id);
    string GenerateJWTToken(UserDTO user);
    bool HasAccessToResource(int userId, ClaimsPrincipal userClaims);

}