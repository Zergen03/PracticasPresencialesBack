namespace ToDoApp.Models
{
    public class Category
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public int User_Id { get; set; }
        public Category() { }

        public Category(string name, int user_Id)
        {
            Name = name;
            User_Id = user_Id;
        }
        
        public Category(int id, string name, int user_Id)
        {
            Id = id;
            Name = name;
            User_Id = user_Id;
        }
    }

}