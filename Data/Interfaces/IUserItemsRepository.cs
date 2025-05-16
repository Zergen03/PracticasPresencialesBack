using ToDoApp.Models;

namespace ToDoApp.Data
{
    public interface IUserItemsRepository
    {
        Task<IEnumerable<UserItem>> GetUserItems();
        Task<IEnumerable<UserItem>> GetUserItems(int userId, int itemId);
        Task<UserItem> CreateUserItem(UserItem userItem);
        Task<UserItem> UpdateUserItem(UserItem userItem);
        Task DeleteUserItem(UserItem userItem);
        Task SaveChangesAsync();

    }
}