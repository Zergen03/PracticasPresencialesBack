using ToDoApp.Models;
using ToDoApp.Data;

namespace ToDoApp.Services;

public class ItemsService : IItemsService
{
    private readonly IItemsRepository _itemsRepository;

    public ItemsService(IItemsRepository itemsRepository)
    {
        _itemsRepository = itemsRepository;
    }

    public async Task<IEnumerable<Items>> GetAllItems()
    {
        try
        {
            return await _itemsRepository.GetAllItems();
        }
        catch (Exception ex)
        {
            throw new Exception($"Error getting items: {ex.Message}");
        }
    }

    public async Task<Items> GetItemById(int id)
    {
        try{
            return await _itemsRepository.GetItemById(id);
        }
        catch (ArgumentException ex)
        {
            throw new ArgumentException($"Invalid item ID: {ex.Message}");
        }
        catch (Exception ex)
        {
            throw new Exception($"Error getting item: {ex.Message}");
        }
    }

    public async Task<Items> AddItem(Items item)
    {
        try
        {
            return await _itemsRepository.AddItem(item);
        }
        catch (ArgumentException ex)
        {
            throw new ArgumentException($"Invalid item: {ex.Message}");
        }
        catch (Exception ex)
        {
            throw new Exception($"Error adding item: {ex.Message}");
        }
    }

    public async Task<Items> UpdateItem(Items item)
    {
        try
        {
            return await _itemsRepository.UpdateItem(item);
        }
        catch (ArgumentException ex)
        {
            throw new ArgumentException($"Invalid item: {ex.Message}");
        }
        catch (Exception ex)
        {
            throw new Exception($"Error updating item: {ex.Message}");
        }
    }

    public async Task DeleteItem(int id)
    {
        try
        {
            await _itemsRepository.DeleteItem(id);
        }
        catch (ArgumentException ex)
        {
            throw new ArgumentException($"Invalid item ID: {ex.Message}");
        }
        catch (Exception ex)
        {
            throw new Exception($"Error deleting item: {ex.Message}");
        }
    }
}