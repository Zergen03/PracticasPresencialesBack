namespace ToDoApp.DTOs.Tasks;

public record TaskDTO
{
    public int Id { get; set; }
    public string Name { get; set; }
    public string Description { get; set; }
    public int GoldReward { get; set; }
    public int XpReward { get; set; }
    public DateTime ExpirationDate { get; set; }
    public int Difficulty { get; set; }
    public int CategoryId { get; set; }

    public TaskDTO() { }
}
