using ToDoApp.Models;

public interface ICategoryRepository
{
    Task<IEnumerable<Category>> GetAll();
    Task <Category> GetByID(int idCategory);
    Task<Category> GetByName(string name);
    Task<int> Update(int idCategory);
    Task<int> Delete(Category category);
    Task<int> Insert (Category category);


}
