using Microsoft.AspNetCore.Mvc;
using ToDoApp.Models;
using ToDoApp.Services;

namespace ToDoApp.Controllers;

[Route("api/[controller]")]
[ApiController]
public class TaskController : ControllerBase
{
    private readonly ITaskService _taskService;
    public TaskController(ITaskService taskService)
    {
        _taskService = taskService;
    }

    // Endpoint para obtener todas las tareas
    [HttpGet]
    public async Task<ActionResult<IEnumerable<ToDoTask>>> GetTasks()
    {
        try
        {
            var tasks = await _taskService.GetTasks();
            return Ok(tasks);
        }
        catch (Exception ex)
        {
            return BadRequest(ex.Message);
        }
    }

    // Endpoint para obtener una tarea por ID
    [HttpGet("{id}")]
    public async Task<ActionResult<ToDoTask>> GetTask(int id)
    {
        try
        {
            var task = await _taskService.GetTask(id);
            return Ok(task);
        }
        catch (Exception ex)
        {
            return BadRequest(ex.Message);
        }
    }

    // Endpoint para obtener todas las tareas de un usuario
    // [HttpGet("user/{userId}")]
    // public async Task<ActionResult<IEnumerable<Task>>> GetTasksByUser(int userId)
    // {
    //     try
    //     {
    //         var tasks = await _taskService.GetTasksByUser(userId);
    //         return Ok(tasks);
    //     }
    //     catch (Exception ex)
    //     {
    //         return BadRequest(ex.Message);
    //     }
    // }

    // Endpoint para crear una tarea
    [HttpPost]
    public async Task<ActionResult<ToDoTask>> CreateTask([FromBody] ToDoTask task)
    {
        try
        {
            var newTask = await _taskService.CreateTask(task);
            return Ok(newTask);
        }
        catch (Exception ex)
        {
            return BadRequest(ex.Message);
        }
    }

    // Endpoint para actualizar una tarea
    [HttpPut("{id}")]
    public async Task<ActionResult<ToDoTask>> UpdateTask(int id, [FromBody] ToDoTask task)
    {
        try
        {
            var updatedTask = await _taskService.UpdateTask(id, task);
            return Ok(updatedTask);
        }
        catch (Exception ex)
        {
            return BadRequest(ex.Message);
        }
    }

    // Endpoint para eliminar una tarea
    [HttpDelete("{id}")]
    public async Task<ActionResult<ToDoTask>> DeleteTask(int id)
    {
        try
        {
            await _taskService.DeleteTask(id);
            return Ok();
        }
        catch (Exception ex)
        {
            return BadRequest(ex.Message);
        }
    }
}