using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Threading.Tasks;
using ToDoApp.Models;

public class TaskRepository : ITaskRepository
{
    private readonly ApplicationDbContext _context;

    public TaskRepository(ApplicationDbContext context)
    {
        _context = context;
    }

    // Obtener todas las tareas
    public async Task<IEnumerable<Tasks>> GetAll()
    {
        return await _context.TASKS.Include(t => t.Category).ToListAsync();
    }

    // Obtener una tarea por su ID
    public async Task<Tasks> GetByID(int idtasks)
    {
        return await _context.TASKS.Include(t => t.Category)
                                   .FirstOrDefaultAsync(t => t.ID == idtasks);
    }

    // Obtener una tarea por su nombre
    public async Task<Tasks> GetByName(string name)
    {
        return await _context.TASKS.Include(t => t.Category)
                                   .FirstOrDefaultAsync(t => t.NAME == name);
    }

    // Insertar una nueva tarea
    public async Task<int> Insert(Tasks tasks)
    {
        _context.TASKS.Add(tasks);
        await _context.SaveChangesAsync();
        return tasks.ID; // Retorna el ID de la tarea insertada
    }

    // Actualizar una tarea existente
    public async Task<int> Update(int idtasks)
    {
        var task = await _context.TASKS.FindAsync(idtasks);
        if (task != null)
        {
            _context.Entry(task).State = EntityState.Modified;
            await _context.SaveChangesAsync();
            return task.ID;
        }
        return 0;
    }

    // Eliminar una tarea
    public async Task<int> Delete(Tasks tasks)
    {
        _context.TASKS.Remove(tasks);
        await _context.SaveChangesAsync();
        return tasks.ID;
    }
}
