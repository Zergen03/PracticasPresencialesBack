namespace ToDoApp.DTOs.Categories;

public record CategoryDTO
{
    public int Id { get; set; }
    public int UserId { get; set; }
    public string Name { get; set; } = default!;

    public CategoryDTO() { }
    
    public CategoryDTO(int user_Id, string name)
    {
        UserId = user_Id;
        Name = name;
    }
}
