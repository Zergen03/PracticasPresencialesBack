using Microsoft.EntityFrameworkCore;
using ToDoApp.Models;

public class ApplicationDbContext : DbContext
{
    public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options) { }

    public DbSet<User> USERS { get; set; }
    public DbSet<Category> CATEGORIES { get; set; }
    // public DbSet<Item> ITEMS { get; set; }
    // public DbSet<Task> TASKS { get; set; }
    public DbSet<UserItems> USERITEMS { get; set; }
    public DbSet<Item> ITEMS { get; set; }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        base.OnModelCreating(modelBuilder);
    }
}
