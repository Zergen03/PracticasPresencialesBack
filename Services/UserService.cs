using ToDoApp.Models;
using ToDoApp.DTOs.Users;
using AutoMapper;
using System.ComponentModel.DataAnnotations;
using ToDoApp.Data.Interfaces;
using ToDoApp.Services.Interfaces;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using Microsoft.Extensions.Configuration;

namespace ToDoApp.Services
{
    public class UserService : IUserService
    {
        private readonly IUserRepository _userRepository;
        private readonly IMapper _mapper;
        private readonly IConfiguration _configuration;

        public UserService(IUserRepository userRepository, IMapper mapper, IConfiguration configuration)
        {
            _userRepository = userRepository;
            _mapper = mapper;
            _configuration = configuration;
        }

        public async Task<IEnumerable<UserDTO>> GetUsers(string? name)
        {
            try
            {
                var users = await _userRepository.GetUsers(name);
                return _mapper.Map<IEnumerable<UserDTO>>(users);
            }
            catch (Exception ex)
            {
                throw new ArgumentException($"Error getting users: {ex.Message}");
            }
        }

        public async Task<UserDTO> GetUser(int id)
        {
            try
            {
                var user = await _userRepository.GetUser(id);
                if (user == null)
                {
                    throw new ArgumentException($"User with ID {id} not found.");
                }
                return _mapper.Map<UserDTO>(user);
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

        public async Task<UserDTO> Login(LoginDTO LoginDTO)
        {
            try
            {
                var validationResults = new List<ValidationResult>();
                var validationContext = new ValidationContext(LoginDTO);
                if (!Validator.TryValidateObject(LoginDTO, validationContext, validationResults, true))
                {
                    var errors = string.Join("; ", validationResults.Select(v => v.ErrorMessage));
                    throw new ArgumentException($"Validation failed: {errors}");
                }
                var users = await _userRepository.GetUsers(LoginDTO.Name);
                var user = users.FirstOrDefault();

                if (user == null || !BCrypt.Net.BCrypt.Verify(LoginDTO.Password, user.Password))
                {
                    throw new InvalidOperationException("Invalid email or password.");
                }

                return _mapper.Map<UserDTO>(user);
            }
            catch (ArgumentException ex)
            {
                throw new ArgumentException($"User login failed: {ex.Message}");
            }
            catch (Exception ex)
            {
                throw new Exception($"An unexpected error occurred: {ex.Message}");
            }
        }

        public async Task<UserDTO> CreateUser(CreateUserDTO userDTO)
        {
            try
            {

                var validationResults = new List<ValidationResult>();
                var validationContext = new ValidationContext(userDTO);

                if (!Validator.TryValidateObject(userDTO, validationContext, validationResults, true))
                {
                    var errors = string.Join("; ", validationResults.Select(v => v.ErrorMessage));
                    throw new ArgumentException($"Validation failed: {errors}");
                }

                var user = _mapper.Map<User>(userDTO);

                var existingUser = await _userRepository.GetUsers(user.Name);
                if (existingUser.Any())
                {
                    throw new InvalidOperationException("A user with the same email already exists.");
                }

                user.Password = BCrypt.Net.BCrypt.HashPassword(user.Password);

                await _userRepository.CreateUser(user);
                await _userRepository.SaveChangesAsync();

                return _mapper.Map<UserDTO>(user);
            }
            catch (InvalidOperationException ex)
            {
                throw new InvalidOperationException($"User registration failed: {ex.Message}");
            }
            catch (ArgumentException ex)
            {
                throw new ArgumentException($"User registration failed: {ex.Message}");
            }
            catch (Exception ex)
            {
                throw new Exception($"An unexpected error occurred: {ex.Message}");
            }
        }

        public async Task<UserDTO> UpdateUser(int id, UpdateUserDTO dto)
        {
            try
            {
                var user = await _userRepository.GetUser(id);
                if (user == null)
                {
                    throw new ArgumentException($"User with ID {id} not found.");
                }
                _mapper.Map(dto, user);
                user.Id = id;

                user.Password = BCrypt.Net.BCrypt.HashPassword(user.Password);
                var result = await _userRepository.UpdateUser(user);
                await _userRepository.SaveChangesAsync();
                return _mapper.Map<UserDTO>(result);
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

        public string GenerateJWTToken(UserDTO user)
        {
            var jwtSecret = _configuration["JWT_SECRET"];
            if (string.IsNullOrEmpty(jwtSecret))
            {
                throw new InvalidOperationException("JWT_SECRET is not configured.");
            }

            var key = new SymmetricSecurityKey(System.Text.Encoding.UTF8.GetBytes(jwtSecret));

            var claims = new List<Claim>
           {
               new Claim("userName", user.Name),
               new Claim("userId", user.Id.ToString()),
           };

            var token = new JwtSecurityToken(
                issuer: _configuration["JWT_ISSUER"],
                audience: _configuration["JWT_AUDIENCE"],
                claims: claims,
                expires: DateTime.UtcNow.AddHours(1),
                signingCredentials: new SigningCredentials(key, SecurityAlgorithms.HmacSha256)
            );

            return new JwtSecurityTokenHandler().WriteToken(token);
        }
    }
}