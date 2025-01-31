using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ToDoApp.Models
{
    public class Tasks
    {
        [Key]
        public int ID { get; set; } // Representa la columna ID (autoincremental)

        [Required]
        [MaxLength(255)]
        public string NAME { get; set; } // Representa la columna NAME

        [Required]
        public string DESCRIPTION { get; set; } // Representa la columna DESCRIPTION

        [Required]
        public int GOLDREWARD { get; set; } // Representa la columna GOLDREWARD

        [Required]
        public int XPREWARD { get; set; } // Representa la columna XPREWARD

        [Required]
        public DateTime EXPIRATIONDATE { get; set; } // Representa la columna EXPIRATIONDATE

        [Required]
        public int DIFFICULTY { get; set; } // Representa la columna DIFFICULTY

        public int CATEGORY_ID { get; set; } // Representa la columna CATEGORY_ID

        [ForeignKey("CATEGORY_ID")]
        public virtual Category Category { get; set; } // Relación con la tabla CATEGORIES (clase Category)
    }
}
