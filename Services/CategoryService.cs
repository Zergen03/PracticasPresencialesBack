using ToDoApp.Models;
using ToDoApp.Data;
using ToDoApp.DTOs.Categories;
using AutoMapper;

namespace ToDoApp.Services;

public class CategoryService : ICategoryService
{
    private readonly ICategoryRepository _categoryRepository;
    private readonly IMapper _mapper;

    public CategoryService(ICategoryRepository categoryRepository, IMapper mapper)
    {
        _mapper = mapper;
        _categoryRepository = categoryRepository;
    }

    public async Task<IEnumerable<CategoryDTO>> GetCategories()
    {
        try
        {
            var categories = await _categoryRepository.GetCategories();
            var mappedCategories = _mapper.Map<IEnumerable<CategoryDTO>>(categories);
            return mappedCategories;
        }
        catch (Exception ex)
        {
            throw new ArgumentException($"Error getting categories: {ex.Message}");
        }
    }

    public async Task<CategoryDTO> GetCategory(int id)
    {
        try
        {
            var category = await _categoryRepository.GetCategory(id);
            var mappedCategory = _mapper.Map<CategoryDTO>(category);
            return mappedCategory;
        }
        catch (ArgumentException ex)
        {
            throw new ArgumentException($"Invalid category ID: {ex.Message}");
        }
        catch (Exception ex)
        {
            throw new ArgumentException($"Error getting category: {ex.Message}");
        }
    }
    public async Task<CategoryDTO> CreateCategory(CreateCategoryDTO categoryDTO)
    {
        try
        {
            var mappedCategory = _mapper.Map<Category>(categoryDTO);
            await _categoryRepository.CreateCategory(mappedCategory);
            await _categoryRepository.SaveChangesAsync();
            Console.WriteLine($"Category created: { _mapper.Map<CategoryDTO>(mappedCategory)}");
            return _mapper.Map<CategoryDTO>(mappedCategory);
        }
        catch (Exception ex)
        {
            throw new ArgumentException($"Error creating category: {ex.Message}");
        }
    }

    public async Task<CategoryDTO> UpdateCategory(int id, UpdateCategoryDTO categoryDTO)
    {
        try
        {
            var mappedCategory = _mapper.Map<Category>(categoryDTO);
            await _categoryRepository.UpdateCategory(id, mappedCategory);
            await _categoryRepository.SaveChangesAsync();
            return _mapper.Map<CategoryDTO>(mappedCategory);
        }
        catch (ArgumentException ex)
        {
            throw new ArgumentException($"Invalid category ID: {ex.Message}");
        }
        catch (Exception ex)
        {
            throw new ArgumentException($"Error updating category: {ex.Message}");
        }
    }

    public async Task DeleteCategory(int id)
    {
        try
        {
            await _categoryRepository.DeleteCategory(id);
        }
        catch (ArgumentException ex)
        {
            throw new ArgumentException($"Invalid category ID: {ex.Message}");
        }
        catch (Exception ex)
        {
            throw new ArgumentException($"Error deleting category: {ex.Message}");
        }
    }
}