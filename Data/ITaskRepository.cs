using ToDoApp.Models;

public interface ITaskRepository
{
    Task<IEnumerable<Tasks>> GetAll();
    Task<Tasks> GetByID(int idtasks);
    Task<Tasks> GetByName(string name);
    Task<int> Update(int idtasks);
    Task<int> Delete(Tasks tasks);
    Task<int> Insert(Tasks tasks);

}