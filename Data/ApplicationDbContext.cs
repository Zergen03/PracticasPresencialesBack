using Microsoft.EntityFrameworkCore;
using ToDoApp.Models;

public class ApplicationDbContext : DbContext
{
    public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options) { }

    public DbSet<User> USERS { get; set; }
    public DbSet<Category> CATEGORIES { get; set; }
    public DbSet<ToDoTask> TASKS { get; set; }
    public DbSet<UserItems> USERITEMS { get; set; }
    public DbSet<Items> ITEMS { get; set; }
    public DbSet<UserItem> USERITEMS { get; set; }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        base.OnModelCreating(modelBuilder);
    }
}
