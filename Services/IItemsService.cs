using ToDoApp.Models;

namespace ToDoApp.Services;

public interface IItemsService
{
    Task<IEnumerable<Items>> GetAllItems();
    Task<Items> GetItemById(int id);
    Task<Items> AddItem(Items item);
    Task<Items> UpdateItem(Items item);
    Task DeleteItem(int id);
}