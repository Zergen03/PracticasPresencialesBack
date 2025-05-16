using ToDoApp.Models;
using ToDoApp.Data;
using ToDoApp.DTOs.Users;

namespace ToDoApp.Services
{
    public class UserService : IUserService
    {
        private readonly IUserRepository _userRepository;

        public UserService(IUserRepository userRepository)
        {
            _userRepository = userRepository;
        }

        public async Task<IEnumerable<User>> GetUsers()
        {
            try
            {
                return await _userRepository.GetUsers();
            }
            catch (Exception ex)
            {
                throw new ArgumentException($"Error getting users: {ex.Message}");
            }
        }

        public async Task<User> GetUser(int id)
        {
            try
            {
                return await _userRepository.GetUser(id);
            }
            catch (ArgumentException ex)
            {
                throw new ArgumentException($"Invalid user ID: {ex.Message}");
            }
            catch (Exception ex)
            {
                throw new ArgumentException($"Error getting user: {ex.Message}");
            }
        }

        public async Task<User> GetUser(string name)
        {
            try
            {
                return await _userRepository.GetUser(name);
            }
            catch (ArgumentException ex)
            {
                throw new ArgumentException($"Invalid user name: {ex.Message}");
            }
            catch (Exception ex)
            {
                throw new ArgumentException($"Error getting user: {ex.Message}");
            }
        }

        public async Task<User> Login(string _name, string _password)
        {
            User? user = await _userRepository.GetUser(_name);
            if (user == null || user.Password != _password)
            {
                throw new System.Exception("User or password incorrect");
            }
            return user;
        }

        public async Task<User> CreateUser(UserDTO user)
        {
            try
            {
                User newUser = new User
                {
                    Name = user.Name,
                    Password = user.Password,
                    Life = 50,
                    Xp = 0,
                    Gold = 0
                };
                return await _userRepository.CreateUser(newUser);
            }
            catch (ArgumentException ex)
            {
                throw new ArgumentException($"Invalid user: {ex.Message}");
            }
            catch (Exception ex)
            {
                throw new ArgumentException($"Error creating user: {ex.Message}");
            }
        }

        public async Task<User> UpdateUser(User user)
        {
            try
            {
                return await _userRepository.UpdateUser(user);
            }
            catch (ArgumentException ex)
            {
                throw new ArgumentException($"Invalid user: {ex.Message}");
            }
            catch (Exception ex)
            {
                throw new ArgumentException($"Error updating user: {ex.Message}");
            }
        }

        public async Task DeleteUser(int id)
        {
            try
            {
                await _userRepository.DeleteUser(id);
            }
            catch (ArgumentException ex)
            {
                throw new ArgumentException($"Invalid user ID: {ex.Message}");
            }
            catch (Exception ex)
            {
                throw new ArgumentException($"Error deleting user: {ex.Message}");
            }
        }
    }
}