using ToDoApp.Models;
using ToDoApp.Data;
using ToDoApp.DTOs.UserItems;
using AutoMapper;


namespace ToDoApp.Services;

public class UserItemsService : IUserItemsService
{
    private readonly IUserItemsRepository _userItemsRepository;
    private readonly IMapper _mapper;

    public UserItemsService(IUserItemsRepository userItemsRepository, IMapper mapper)
    {
        _userItemsRepository = userItemsRepository;
        _mapper = mapper;
    }

    public async Task<IEnumerable<UserItemDTO>> GetUserItems()
    {
        try
        {
            var userItems = await _userItemsRepository.GetUserItems();
            return _mapper.Map<IEnumerable<UserItemDTO>>(userItems);
            
        }
        catch (Exception ex)
        {
            throw new ArgumentException($"Error getting user items: {ex.Message}");
        }
    }

    public async Task<IEnumerable<UserItemDTO>> GetUserItem(int userId, int? itemId)
    {
        try
        {
            var userItmes = await _userItemsRepository.GetUserItem(userId, itemId);
            return _mapper.Map<IEnumerable<UserItemDTO>>(userItmes);
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

    public async Task<IEnumerable<UserItemDTO>> GetUserItems(int user_id, int itemId)
    {
        try
        {
            var userItem = await _userItemsRepository.GetUserItem(user_id, itemId);
            return _mapper.Map<IEnumerable<UserItemDTO>>(userItem);
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

    public async Task<UserItemDTO> CreateUserItem(CreateUserItemDTO dto
        )
    {
        try
        {
            if (dto == null)
            {
                throw new ArgumentNullException(nameof(dto), "User item cannot be null");
            }

            var userItem = _mapper.Map<UserItem>(dto);
            await _userItemsRepository.CreateUserItem(userItem);
            await _userItemsRepository.SaveChangesAsync();
            return _mapper.Map<UserItemDTO>(userItem);
        }
        catch (Exception ex)
        {
            throw new ArgumentException($"Error creating user item: {ex.Message}");
        }
    }

    public async Task DeleteUserItem(int userId, int? itemId)
    {
        try
        {
            var userItem = await _userItemsRepository.GetUserItem(userId, itemId);
            if (userItem == null)
            {
                throw new ArgumentException($"User item with ID {userId} not found");
            }
            await _userItemsRepository.DeleteUserItem(userId, itemId);
            await _userItemsRepository.SaveChangesAsync();
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