using ToDoApp.Models;
using ToDoApp.Data;
using AutoMapper;
using ToDoApp.DTOs.Tasks;

namespace ToDoApp.Services
{
    public class TaskService : ITaskService
    {
        private readonly ITaskRepository _taskRepository;
        private readonly IMapper _mapper;

        public TaskService(ITaskRepository taskRepository, IMapper mapper)
        {
            _mapper = mapper;
            _taskRepository = taskRepository;
        }

        public async Task<IEnumerable<TaskDTO>> GetTasks()
        {
            try
            {
                var tasks = await _taskRepository.GetTasks();
                var mappedTasks = _mapper.Map<IEnumerable<TaskDTO>>(tasks);
                return mappedTasks;
            }
            catch (Exception ex)
            {
                throw new Exception($"Error getting tasks: {ex.Message}");
            }
        }

        public async Task<TaskDTO> GetTask(int id)
        {
            try
            {
                var task = await _taskRepository.GetTask(id);
                var mappedTask = _mapper.Map<TaskDTO>(task);
                return mappedTask;
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
        
        public async Task<IEnumerable<TaskDTO>> GetTasksByCategory(int categoryId)
        {
            try
            {
                var tasksByCategory = new List<TaskDTO>();
                var tasks =  await _taskRepository.GetTasks();
                foreach (var task in tasks)
                {
                    if (task.Category_Id == categoryId)
                    {
                        tasksByCategory.Add(_mapper.Map<TaskDTO>(task));
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

        public async Task<TaskDTO> CreateTask(CreateTaskDTO taskDTO)
        {
            try
            {
                var mappedTask = _mapper.Map<ToDoTask>(taskDTO);
                await _taskRepository.CreateTask(mappedTask);
                await _taskRepository.SaveChangesAsync();
                return _mapper.Map<TaskDTO>(mappedTask);
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

        public async Task<TaskDTO> UpdateTask(int id, UpdateTaskDTO task)
        {
            try
            {
                var mappedTask = _mapper.Map<ToDoTask>(task);
                mappedTask.Id = id;
                await _taskRepository.UpdateTask(mappedTask);
                await _taskRepository.SaveChangesAsync();
                return _mapper.Map<TaskDTO>(mappedTask);
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