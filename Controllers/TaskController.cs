using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Threading.Tasks;
using ToDoApp.Models;
using ToDoApp.Services;

[Route("api/[controller]")]
[ApiController]
public class TasksController : ControllerBase
{
    private readonly TaskService _service;

    public TasksController(TaskService taskService)
    {
        _service = taskService;
    }

    // Obtener todas las tareas
    [HttpGet]
    public async Task<ActionResult<IEnumerable<Tasks>>> GetAll()
    {
        var tasks = await _service.GetAll();
        return Ok(tasks);
    }

    // Obtener una tarea por su ID
    [HttpGet("{id}")]
    public async Task<ActionResult<Tasks>> GetById(int id)
    {
        var task = await _service.GetById(id);
        if (task == null)
        {
            return NotFound();
        }
        return Ok(task);
    }

    // Obtener una tarea por su nombre
    [HttpGet("name/{name}")]
    public async Task<ActionResult<Tasks>> GetByName(string name)
    {
        var task = await _service.GetByName(name);
        if (task == null)
        {
            return NotFound();
        }
        return Ok(task);
    }

    // Insertar una nueva tarea
    [HttpPost]
    public async Task<ActionResult<int>> Insert(Tasks task)
    {
        var id = await _service.Insert(task);
        return CreatedAtAction(nameof(GetById), new { id }, task);
    }

    // Actualizar una tarea
    [HttpPut("{id}")]
    public async Task<IActionResult> Update(int id)
    {
        var updatedId = await _service.Update(id);
        if (updatedId == 0)
        {
            return NotFound();
        }
        return NoContent();
    }

    // Eliminar una tarea
    [HttpDelete("{id}")]
    public async Task<IActionResult> Delete(int id)
    {
        var task = await _service.GetById(id);
        if (task == null)
        {
            return NotFound();
        }

        await _service.Delete(task);
        return NoContent();
    }
}
