using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
namespace ToDoApp.Models
{
    [Table("TASKS")]
    public class ToDoTask
    {
        [Key]
        public int Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public int GoldReward { get; set; }
        public int XpReward { get; set; }
        public DateTime ExpirationDate { get; set; }
        public int Difficulty { get; set; }
        [ForeignKey("Category")]
        public int CategoryId { get; set; }
        public Category Category { get; set; } = default!;

        public ToDoTask(int id, string name, string description, DateTime expirationDate, int difficulty, int category_Id)
        {
            Id = id;
            Name = name;
            Description = description;
            GoldReward = CalculateGold(difficulty);
            XpReward = CalculateXp(difficulty);
            ExpirationDate = expirationDate;
            Difficulty = difficulty;
            CategoryId = category_Id;
        }

        public ToDoTask(string name, string description, DateTime expirationDate, int difficulty, int category_Id)
        {
            Name = name;
            Description = description;
            GoldReward = CalculateGold(difficulty);
            XpReward = CalculateXp(difficulty);
            ExpirationDate = expirationDate;
            Difficulty = difficulty;
            CategoryId = category_Id;
        }

        public ToDoTask(){}

        private int CalculateGold(int difficulty = 1)
        {
            Random random = new Random();
            int _gold = random.Next(1, 5) * difficulty;
            return _gold;
        }
        private int CalculateXp(int difficulty = 1)
        {
            Random random = new Random();
            int _xp = random.Next(5, 20) * difficulty;
            return _xp;
        }
    }
}