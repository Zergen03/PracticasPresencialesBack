using ToDoApp.Models;
using ToDoApp.DTOs.UserItems;

namespace ToDoApp.Services;

public interface IUserItemsService
{
    Task<IEnumerable<UserItemDTO>> GetUserItems();
    Task<IEnumerable<UserItemDTO>> GetUserItem(int userId, int? itemId);
    Task<UserItemDTO> CreateUserItem(CreateUserItemDTO userItem);
    Task DeleteUserItem(int userId, int? itemId);
}