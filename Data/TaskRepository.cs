using Microsoft.EntityFrameworkCore;
using ToDoApp.Models;

namespace ToDoApp.Data;

public class TaskRepository : ITaskRepository
{
    private readonly DBContext _context;

    public TaskRepository(DBContext context)
    {
        _context = context;
    }

    public async Task<IEnumerable<ToDoTask>> GetTasks()
    {
        try
        {
            return await _context.TASKS.ToListAsync();
        }
        catch (Exception ex)
        {
            throw new Exception($"Error getting tasks: {ex.Message}");
        }
    }

    public async Task<ToDoTask> GetTask(int id)
    {
        try
        {
            return await _context.TASKS.FindAsync(id);
        }
        catch (Exception ex)
        {
            throw new Exception($"Error getting task: {ex.Message}");
        }
    }

    public async Task<ToDoTask> CreateTask(ToDoTask task)
    {
        try
        {
            _context.TASKS.Add(task);
            await _context.SaveChangesAsync();
            return task;
        }
        catch (Exception ex)
        {
            throw new Exception($"Error creating task: {ex.Message}");
        }
    }

    public async Task<ToDoTask> UpdateTask(int id, ToDoTask task)
    {
        try
        {
            _context.TASKS.Update(task);
            await _context.SaveChangesAsync();
            return task;
        }
        catch (Exception ex)
        {
            throw new Exception($"Error updating task: {ex.Message}");
        }
    }

    public async Task DeleteTask(int id)
    {
        try
        {
            var task = await _context.TASKS.FindAsync(id);
            _context.TASKS.Remove(task);
            await _context.SaveChangesAsync();
        }
        catch (Exception ex)
        {
            throw new Exception($"Error deleting task: {ex.Message}");
        }
    }
}
