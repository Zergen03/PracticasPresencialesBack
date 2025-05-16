using ToDoApp.Models;
using ToDoApp.Data;
using ToDoApp.Data.Interfaces;
using ToDoApp.DTOs.Items;
using AutoMapper;


namespace ToDoApp.Services;

public class ItemsService : IItemsService
{
    private readonly IItemsRepository _itemsRepository;
    private readonly IMapper _mapper;

    public ItemsService(IItemsRepository itemsRepository, IMapper mapper)
    {
        _itemsRepository = itemsRepository;
        _mapper = mapper;
    }

    public async Task<IEnumerable<ItemDTO>> GetAllItems(string? name)
    {
        try
        {
            var items = await _itemsRepository.GetAllItems(name);
            return _mapper.Map<IEnumerable<ItemDTO>>(items);
        }
        catch (Exception ex)
        {
            throw new Exception($"Error getting items: {ex.Message}");
        }
    }

    public async Task<ItemDTO> GetItemById(int id)
    {
        try{
            var item = await _itemsRepository.GetItemById(id);
            if (item == null)
            {
                throw new ArgumentException($"Item with ID {id} not found.");
            }
            return _mapper.Map<ItemDTO>(item);
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

    public async Task<ItemDTO> AddItem(CreateItemDTO itemDTO)
    {
        try
        {
            if (string.IsNullOrEmpty(itemDTO.Name) || string.IsNullOrEmpty(itemDTO.TypeObject))
            {
                throw new ArgumentException("Item name and type cannot be null or empty.");
            }

            var item = _mapper.Map<Items>(itemDTO);

            var existingItem = await _itemsRepository.GetAllItems(itemDTO.Name);
            if (existingItem.Any())
            {
                throw new ArgumentException($"Item with name {itemDTO.Name} already exists.");
            }
            await _itemsRepository.AddItem(item);
            await _itemsRepository.SaveChangesAsync();
            return _mapper.Map<ItemDTO>(item);
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

    public async Task<ItemDTO> UpdateItem(int id, UpdateItemDTO itemDTO)
    {
        try
        {
            var item = await _itemsRepository.GetItemById(id);
            if (item == null)
            {
                throw new ArgumentException($"Item with ID {id} not found.");
            }
            _mapper.Map(itemDTO, item);
            item.Id = id;
            var result = await _itemsRepository.UpdateItem(item);
            await _itemsRepository.SaveChangesAsync();
            return _mapper.Map<ItemDTO>(result);
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