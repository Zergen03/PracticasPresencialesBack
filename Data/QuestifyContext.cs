using Microsoft.EntityFrameworkCore;
using ToDoApp.Models;

public class QuestifyContext : DbContext
{
    public QuestifyContext(DbContextOptions<QuestifyContext> options) : base(options) { }
    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
    }

    public DbSet<User> USERS { get; set; }
    public DbSet<Category> CATEGORIES { get; set; }
    // public DbSet<Item> ITEMS { get; set; }
    public DbSet<ToDoTask> TASKS { get; set; }
    public DbSet<UserItems> USERITEMS { get; set; }
    public DbSet<Items> ITEMS { get; set; }

}
