using ToDoApp.Models;
using ToDoApp.Data;
using ToDoApp.DTOs.Tasks;

namespace ToDoApp.Services
{
    public interface ITaskService
    {
        Task<IEnumerable<TaskDTO>> GetTasks();
        Task<TaskDTO> GetTask(int id);
        Task<IEnumerable<TaskDTO>> GetTasksByCategory(int categoryId);
        Task<TaskDTO> CreateTask(CreateTaskDTO task);
        Task<TaskDTO> UpdateTask(int id, UpdateTaskDTO task);
        Task DeleteTask(int id);
    }
}