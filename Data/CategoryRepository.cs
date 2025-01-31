using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Threading.Tasks;
using ToDoApp.Models;

public class CategoryRepository : ICategoryRepository
{
    private readonly ApplicationDbContext _context;

    public CategoryRepository(ApplicationDbContext context)
    {
        _context = context;
    }

    // Obtener todas las categorías
    public async Task<IEnumerable<Category>> GetAll()
    {
        try{
        return await _context.CATEGORIES.ToListAsync();
        }
        catch (Exception ex){
            throw new Exception($"Error getting categories: {ex.Message}");
        }
    }

    // Obtener una categoría por su ID
    public async Task<Category> GetByID(int idCategory)
    {
        return await _context.CATEGORIES.FindAsync(idCategory);
    }

    // Obtener una categoría por su nombre
    public async Task<Category> GetByName(string name)
    {
        return await _context.CATEGORIES.FirstOrDefaultAsync(c => c.Name == name);
    }

    // Insertar una nueva categoría
    public async Task<int> Insert(Category category)
    {
        _context.CATEGORIES.Add(category);
        await _context.SaveChangesAsync();
        return category.Id; // Retorna el ID de la nueva categoría insertada
    }

    // Actualizar una categoría existente
    public async Task<int> Update(int idCategory)
    {
        var category = await _context.CATEGORIES.FindAsync(idCategory);
        if (category != null)
        {
            _context.Entry(category).State = EntityState.Modified;
            await _context.SaveChangesAsync();
            return category.Id;
        }
        return 0;
    }

    // Eliminar una categoría
    public async Task<int> Delete(Category category)
    {
        _context.CATEGORIES.Remove(category);
        await _context.SaveChangesAsync();
        return category.Id;
    }


}
