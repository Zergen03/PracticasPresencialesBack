namespace ToDoApp.Models;
public class UserItem
{
    public int UserId { get; set; }
    public User User { get; set; } = default!;
    public int ItemId { get; set; }
    public Items Item { get; set; } = default!;

    public UserItem(int userId, int itemId)
    {
        UserId = userId;
        ItemId = itemId;
    }

    public UserItem()
    {
    }
}