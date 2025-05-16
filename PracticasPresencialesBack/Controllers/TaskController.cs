using Microsoft.AspNetCore.Mvc;
using ToDoApp.Models;
using ToDoApp.Services;
using ToDoApp.DTOs.Tasks;

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
    public async Task<ActionResult<IEnumerable<TaskDTO  >>> GetTasks()
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
    public async Task<ActionResult<TaskDTO>> GetTask(int id)
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

    // Endpoint para obtener todas las tareas de una categoría
    [HttpGet("category/{categoryId}")]
    public async Task<ActionResult<IEnumerable<TaskDTO>>> GetTasksByCategory(int categoryId)
    {
        try
        {
            var tasks = await _taskService.GetTasksByCategory(categoryId);
            return Ok(tasks);
        }
        catch (Exception ex)
        {
            return BadRequest(ex.Message);
        }
    }

    // Endpoint para crear una tarea
    [HttpPost]
    public async Task<ActionResult<TaskDTO>> CreateTask([FromBody] CreateTaskDTO task)
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
    public async Task<ActionResult<TaskDTO>> UpdateTask(int id, [FromBody] UpdateTaskDTO task)
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
    public async Task<ActionResult<TaskDTO>> DeleteTask(int id)
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