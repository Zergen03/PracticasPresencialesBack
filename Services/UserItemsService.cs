using ToDoApp.Models;
using ToDoApp.Data;

namespace ToDoApp.Services;

public class UserItemsService : IUserItemsService
{
    private readonly IUserItemsRepository _userItemsRepository;

    public UserItemsService(IUserItemsRepository userItemsRepository)
    {
        _userItemsRepository = userItemsRepository;
    }

    public async Task<IEnumerable<UserItems>> GetUserItems()
    {
        try
        {
            return await _userItemsRepository.GetUserItems();
        }
        catch (Exception ex)
        {
            throw new ArgumentException($"Error getting user items: {ex.Message}");
        }
    }

    public async Task<UserItems> GetUserItem(int id)
    {
        try
        {
            return await _userItemsRepository.GetUserItem(id);
        }
        catch (ArgumentException ex)
        {
            throw new ArgumentException($"Invalid user item ID: {ex.Message}");
        }
        catch (Exception ex)
        {
            throw new ArgumentException($"Error getting user item: {ex.Message}");
        }
    }

    public async Task<IEnumerable<UserItems>> GetUserItems(int user_id)
    {
        try
        {
            return await _userItemsRepository.GetUserItems(user_id);
        }
        catch (ArgumentException ex)
        {
            throw new ArgumentException($"Invalid user ID: {ex.Message}");
        }
        catch (Exception ex)
        {
            throw new ArgumentException($"Error getting user items: {ex.Message}");
        }
    }

    public async Task<IEnumerable<UserItems>> GetItemsUser(int item_id)
    {
        try
        {
            return await _userItemsRepository.GetItemsUser(item_id);
        }
        catch (ArgumentException ex)
        {
            throw new ArgumentException($"Invalid item ID: {ex.Message}");
        }
        catch (Exception ex)
        {
            throw new ArgumentException($"Error getting user items: {ex.Message}");
        }
    }

    public async Task<UserItems> CreateUserItem(UserItems userItem)
    {
        try
        {
            return await _userItemsRepository.CreateUserItem(userItem);
        }
        catch (Exception ex)
        {
            throw new ArgumentException($"Error creating user item: {ex.Message}");
        }
    }

    public async Task<UserItems> UpdateUserItem(UserItems userItem)
    {
        try
        {
            return await _userItemsRepository.UpdateUserItem(userItem);
        }
        catch (Exception ex)
        {
            throw new ArgumentException($"Error updating user item: {ex.Message}");
        }
    }

    public async Task DeleteUserItem(int id)
    {
        try
        {
            await _userItemsRepository.DeleteUserItem(id);
        }
        catch (ArgumentException ex)
        {
            throw new ArgumentException($"Invalid user item ID: {ex.Message}");
        }
        catch (Exception ex)
        {
            throw new ArgumentException($"Error deleting user item: {ex.Message}");
        }
    }
}