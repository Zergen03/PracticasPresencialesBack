using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using ToDoApp.Models;

public class Category
{
    [Key]
    public int Id { get; set; } 

    [Required]
    [MaxLength(255)]
    public string Name { get; set; } 

    public int User_Id { get; set; } 

    [ForeignKey("User_Id")]
    public virtual User User { get; set; } 
}
