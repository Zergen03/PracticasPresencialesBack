using ToDoApp.Models;
using ToDoApp.Data;

namespace ToDoApp.Services
{
    public class TaskService : ITaskService
    {
        private readonly ITaskRepository _taskRepository;

        public TaskService(ITaskRepository taskRepository)
        {
            _taskRepository = taskRepository;
        }

        public async Task<IEnumerable<ToDoTask>> GetTasks()
        {
            try
            {
                return await _taskRepository.GetTasks();
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
                return await _taskRepository.GetTask(id);
            }
            catch (ArgumentException ex)
            {
                throw new ArgumentException($"Invalid task ID: {ex.Message}");
            }
            catch (Exception ex)
            {
                throw new Exception($"Error getting task: {ex.Message}");
            }
        }
        
        public async Task<IEnumerable<ToDoTask>> GetTasksByCategory(int categoryId)
        {
            try
            {
                var tasksByCategory = new List<ToDoTask>();
                var tasks =  await _taskRepository.GetTasks();
                foreach (var task in tasks)
                {
                    if (task.Category_Id == categoryId)
                    {
                        tasksByCategory.Add(task);
                    }
                }
                return tasksByCategory;
            }
            catch (ArgumentException ex)
            {
                throw new ArgumentException($"Invalid category ID: {ex.Message}");
            }
            catch (Exception ex)
            {
                throw new Exception($"Error getting tasks: {ex.Message}");
            }
        }

        public async Task<ToDoTask> CreateTask(ToDoTask task)
        {
            try
            {
                return await _taskRepository.CreateTask(task);
            }
            catch (ArgumentException ex)
            {
                throw new ArgumentException($"Invalid task: {ex.Message}");
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
                return await _taskRepository.UpdateTask(id, task);
            }
            catch (ArgumentException ex)
            {
                throw new ArgumentException($"Invalid task ID: {ex.Message}");
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
                await _taskRepository.DeleteTask(id);
            }
            catch (ArgumentException ex)
            {
                throw new ArgumentException($"Invalid task ID: {ex.Message}");
            }
            catch (Exception ex)
            {
                throw new Exception($"Error deleting task: {ex.Message}");
            }
        }
    }
}