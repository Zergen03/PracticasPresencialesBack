using System.ComponentModel.DataAnnotations;

namespace ToDoApp.Models;

public class Items{
    [Key]
    public int Id { get; set; }
    [Required] 
    public required string Name { get; set; } = default!;
    [Required]
    public required string TypeObject { get; set; }
    [Required]
    public required int StatsObject { get; set; }
    [Required]
    public required int ValueObject { get; set; }

    public Items(int id, string type, int stats, int value){
        Id = id;
        TypeObject = type;
        StatsObject = stats;
        ValueObject = value; 
    }

    public Items(string type, int stats, int value){
        TypeObject = type;
        StatsObject = stats;
        ValueObject = value; 
    }

    public Items(){}
}