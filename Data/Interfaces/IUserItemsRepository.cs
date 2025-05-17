using ToDoApp.Models;

namespace ToDoApp.Data
{
    public interface IUserItemsRepository
    {
        Task<IEnumerable<UserItem>> GetUserItems();
        Task<IEnumerable<UserItem>> GetUserItem(int userId, int? itemId);
        Task<UserItem> CreateUserItem(UserItem userItem);
        Task DeleteUserItem(int userId, int? itemId);
        Task SaveChangesAsync();

    }
}