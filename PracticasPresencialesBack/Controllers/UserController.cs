using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Threading.Tasks;
using ToDoApp.DTOs.Users;
using ToDoApp.Services.Interfaces;
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
    public async Task<ActionResult<IEnumerable<UserDTO>>> GetUsers([FromQuery] string? name)
    {
        try
        {
            var users = await _userService.GetUsers(name);
            return Ok(users);
        }
        catch (Exception ex)
        {
            return BadRequest(ex.Message);
        }
    }

    // Endpoint para obtener un usuario por ID
    [HttpGet("{id}")]
    public async Task<ActionResult<UserDTO>> GetUser(int id)
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

    // Endpoint para hacer login
    [HttpPost("login")]
    public async Task<IActionResult> LoginUser([FromBody] LoginDTO loginUserDTO)
    {
        var user = await _userService.Login(loginUserDTO);
        if (user == null)
        {
            return Unauthorized();
        }
        var token = _userService.GenerateJWTToken(user);
        return Ok(new { token });
    }

    // Endpoint para crear un usuario
    [HttpPost]
    public async Task<ActionResult<UserDTO>> PostUser([FromBody] CreateUserDTO user)
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
    public async Task<ActionResult<UserDTO>> PutUser(int id, [FromBody]UpdateUserDTO user)
    {
        try
        {
            await _userService.UpdateUser(id, user);
            return Ok();
        }
        catch (Exception ex)
        {
            return BadRequest(ex.Message);
        }
    }

    // Endpoint para eliminar un usuario
    [HttpDelete("{id}")]
    public async Task<ActionResult<UserDTO>> DeleteUser(int id)
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
