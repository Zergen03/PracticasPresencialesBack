using System.ComponentModel.DataAnnotations;

namespace ToDoApp.DTOs.Tasks;

public class UpdateTaskDTO
{
    [Required(ErrorMessage = "El nombre es obligatorio.")]
    [StringLength(50, MinimumLength = 3, ErrorMessage = "El nombre debe tener entre 3 y 50 caracteres.")]
    public string Name { get; set; }

    [Required(ErrorMessage = "La descripción es obligatoria.")]
    [StringLength(500, MinimumLength = 4, ErrorMessage = "La descripción debe tener entre 4 y 500 caracteres.")]
    public string Description { get; set; }

    [Required(ErrorMessage = "La fecha de expiración es obligatoria.")]
    [DataType(DataType.Date)]
    public DateTime ExpirationDate { get; set; }

    [Required(ErrorMessage = "La dificultad es obligatoria.")]
    public int Difficulty { get; set; }


    [Required(ErrorMessage = "El ID de la categoría es obligatorio.")]
    [Range(1, int.MaxValue, ErrorMessage = "El ID de la categoría debe ser un número positivo.")]
    public int Category_Id { get; set; }

    public UpdateTaskDTO() { }
}
