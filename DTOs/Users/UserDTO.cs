namespace ToDoApp.DTOs.Users;

public record UserDTO
{
    public int Id { get; set; }
    public string Name { get; set; } = default!;
    public int Life { get; set; } = default!;
    public int Xp { get; set; } = default!;
    public int Gold { get; set; } = default!;
    public int Lvl { get; set; } = default!;
}