namespace ToDoApp.Models
{
    public class UserItems
    {
        public int Id { get; set; }
        public int User_Id { get; set; }
        public int Item_Id { get; set; }

        public UserItems(int id, int userId, int itemId)
        {
            Id = id;
            User_Id = userId;
            Item_Id = itemId;
        }
        public UserItems(int userId, int itemId)
        {
            User_Id = userId;
            Item_Id = itemId;
        }
        public UserItems(){}
    }
}