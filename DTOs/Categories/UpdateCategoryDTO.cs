using System.ComponentModel.DataAnnotations;

namespace ToDoApp.DTOs.Categories;

public class UpdateCategoryDTO
{
    [Required(ErrorMessage = "El nombre es obligatorio.")]
    [StringLength(50, MinimumLength = 3, ErrorMessage = "El nombre debe tener entre 3 y 50 caracteres.")]
    public string Name { get; set; }

    [Required(ErrorMessage = "El ID de usuario es obligatorio.")]
    public int User_Id { get; set; }
}

