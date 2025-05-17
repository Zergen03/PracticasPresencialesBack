using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ToDoApp.Models
{
    public class Category
    {
        [Key]
        public int Id { get; set; }
        public string Name { get; set; }
        [ForeignKey("User")]
        public int UserId { get; set; }
        public User User { get; set; } = default!;
        public ICollection<ToDoTask> Tasks { get; set; } = new List<ToDoTask>();
        public Category() { }

        public Category(string name, int user_Id)
        {
            Name = name;
            UserId = user_Id;
        }
        
        public Category(int id, string name, int user_Id)
        {
            Id = id;
            Name = name;
            UserId = user_Id;
        }
    }

}