using Microsoft.EntityFrameworkCore;
using ToDoApp.Models;

public class ApplicationDbContext : DbContext
{
    public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options) { }

    public DbSet<User> USERS { get; set; }
    // public DbSet<Category> Categories { get; set; }
    // public DbSet<Item> Items { get; set; }
    // public DbSet<Task> Tasks { get; set; }
    // public DbSet<UserItem> UserItems { get; set; }
    public DbSet<Item> ITEMS { get; set; }
    public DbSet<UserItem> USERITEMS { get; set; }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        base.OnModelCreating(modelBuilder);
    }
}
