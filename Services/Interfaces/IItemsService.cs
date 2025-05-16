using ToDoApp.Models;
using ToDoApp.DTOs.Items;

namespace ToDoApp.Services;

public interface IItemsService
{
    Task<IEnumerable<ItemDTO>> GetAllItems(string? name);
    Task<ItemDTO> GetItemById(int id);
    Task<ItemDTO> AddItem(CreateItemDTO item);
    Task<ItemDTO> UpdateItem(int id, UpdateItemDTO item);
    Task DeleteItem(int id);
}