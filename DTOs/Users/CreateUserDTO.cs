namespace ToDoApp.DTOs.Users;
    public record CreateUserDTO
    {
        public string Name { get; set; } = default!;
        public string Password { get; set; } = default!;
        public string Role { get; set; } = "user";
}
