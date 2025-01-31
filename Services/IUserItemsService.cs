using ToDoApp.Models;

namespace ToDoApp.Services;

public interface IUserItemsService
{
    Task<IEnumerable<UserItems>> GetUserItems();
    Task<UserItems> GetUserItem(int id);
    Task<IEnumerable<UserItems>> GetUserItems(int user_id);
    Task<IEnumerable<UserItems>> GetItemsUser(int item_id);
    Task<UserItems> CreateUserItem(UserItems userItem);
    Task<UserItems> UpdateUserItem(UserItems userItem);
    Task DeleteUserItem(int id);
}