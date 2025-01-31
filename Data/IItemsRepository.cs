using ToDoApp.Models;

namespace ToDoApp.Data
{
    public interface IItemsRepository
    {
        Task<IEnumerable<Items>> GetAllItems();
        Task<Items> GetItemById(int id);
        Task<Items> AddItem(Items item);
        Task<Items> UpdateItem(Items item);
        Task DeleteItem(int id);
    }
}