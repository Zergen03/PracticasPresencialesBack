namespace ToDoApp.DTOs.Items
{
    public record CreateItemDTO
    {
        public string Name { get; set; } = default!;
        public string TypeObject { get; set; } = default!;
        public int StatsObject { get; set; }
        public int ValueObject { get; set; }
    }
}
