using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Threading.Tasks;
using ToDoApp.Models;
using ToDoApp.Services;
using ToDoApp.DTOs.Users;

namespace ToDoApp.Controllers;

[Route("api/[controller]")]
[ApiController]
public class UsersController : ControllerBase
{
    private readonly IUserService _userService;
    public UsersController(IUserService userService)
    {
        _userService = userService;
    }

    // Endpoint para obtener todos los usuarios
    [HttpGet]
    public async Task<ActionResult<IEnumerable<User>>> GetUsers()
    {
        try
        {
            var users = await _userService.GetUsers();
            return Ok(users);
        }
        catch (Exception ex)
        {
            return BadRequest(ex.Message);
        }
    }

    // Endpoint para obtener un usuario por ID
    [HttpGet("{id}")]
    public async Task<ActionResult<User>> GetUser(int id)
    {
        try
        {
            var user = await _userService.GetUser(id);
            return Ok(user);
        }
        catch (Exception ex)
        {
            return BadRequest(ex.Message);
        }
    }

    // Endpoint para obtener un usuario por nombre
    [HttpGet("byname/{name}")]
    public async Task<ActionResult<User>> GetUserByName(string name)
    {
        try
        {
            var user = await _userService.GetUser(name);
            return Ok(user);
        }
        catch (Exception ex)
        {
            return BadRequest(ex.Message);
        }
    }

    // Endpoint para hacer login
    [HttpPost("login")]
    public async Task<ActionResult<User>> Login([FromBody] UserDTO user)
    {
        try
        {
            var loggedUser = await _userService.Login(user.Name, user.Password);
            return Ok(loggedUser);
        }
        catch (Exception ex)
        {
            return BadRequest(ex.Message);
        }
    }

    // Endpoint para crear un usuario
    [HttpPost]
    public async Task<ActionResult<User>> PostUser([FromBody] UserDTO user)
    {
        try
        {
            await _userService.CreateUser(user);
            return Ok();
        }
        catch (Exception ex)
        {
            return BadRequest(ex.Message);
        }
    }

    // Endpoint para actualizar un usuario
    [HttpPut("{id}")]
    public async Task<ActionResult<User>> PutUser(int id, User user)
    {
        if (id != user.Id)
        {
            return BadRequest();
        }
        try
        {
            await _userService.UpdateUser(user);
            return Ok();
        }
        catch (Exception ex)
        {
            return BadRequest(ex.Message);
        }
    }

    // Endpoint para eliminar un usuario
    [HttpDelete("{id}")]
    public async Task<ActionResult<User>> DeleteUser(int id)
    {
        try
        {
            await _userService.DeleteUser(id);
            return Ok();
        }
        catch (Exception ex)
        {
            return BadRequest(ex.Message);
        }
    }
}
