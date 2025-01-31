using ToDoApp.Models;

namespace ToDoApp.Services;

public class CategoryService
{
    private readonly CategoryRepository _repository;

    public CategoryService(CategoryRepository repository)
    {
        _repository = repository;
    }
    public async Task<IEnumerable<Category>> GetAll()
    {
        return await _repository.GetAll();
    }
    public Task<Category> GetById(int id) {
        return _repository.GetByID(id);
    }
    public Task<Category> GetByName(string name) {
        return _repository.GetByName(name);
    }
    public Task<int> Insert (Category category) {
        return _repository.Insert(category);
    }
    public Task<int> Delete (Category category) {
        return _repository.Delete(category);
    }
    public Task<int> Update (int id) {
        return _repository.Update(id);
    }
}