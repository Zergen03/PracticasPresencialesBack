using ToDoApp.Models;
using ToDoApp.Data;

namespace ToDoApp.Services
{
    public interface ITaskService
    {
        Task<IEnumerable<ToDoTask>> GetTasks();
        Task<ToDoTask> GetTask(int id);
        Task<ToDoTask> CreateTask(ToDoTask task);
        Task<ToDoTask> UpdateTask(int id, ToDoTask task);
        Task DeleteTask(int id);
    }
}