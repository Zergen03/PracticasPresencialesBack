using ToDoApp.Models;

namespace ToDoApp.Data
{
    public interface ITaskRepository
    {
        Task<IEnumerable<ToDoTask>> GetTasks();
        Task<ToDoTask> GetTask(int id);
        Task<ToDoTask> CreateTask(ToDoTask task);
        Task<ToDoTask> UpdateTask(ToDoTask task);
        Task DeleteTask(int id);
        Task SaveChangesAsync();
    }
}