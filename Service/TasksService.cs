using ToDoApp.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace ToDoApp.Services
{
    public class TaskService
    {
        private readonly TaskRepository _repository;

        public TaskService(TaskRepository repository)
        {
            _repository = repository;
        }

        public Task<IEnumerable<Tasks>> GetAll()
        {
            return _repository.GetAll();
        }

        public Task<Tasks> GetById(int id)
        {
            return _repository.GetByID(id);
        }

        public Task<Tasks> GetByName(string name)
        {
            return _repository.GetByName(name);
        }

        public Task<int> Insert(Tasks task)
        {
            return _repository.Insert(task);
        }

        public Task<int> Delete(Tasks task)
        {
            return _repository.Delete(task);
        }

        public Task<int> Update(int id)
        {
            return _repository.Update(id);
        }
    }
}
