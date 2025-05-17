using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using ToDoApp.Models;

public class QuestifyContext : DbContext
{
    public QuestifyContext(DbContextOptions<QuestifyContext> options) : base(options) { }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<UserItem>()
            .HasKey(u => new { u.UserId, u.ItemId });

        modelBuilder.Entity<UserItem>()
            .HasOne(u => u.User)
            .WithMany(u => u.UserItem)
            .HasForeignKey(u => u.UserId)
            .OnDelete(DeleteBehavior.Cascade);

        modelBuilder.Entity<UserItem>()
            .HasOne(u => u.Item)
            .WithMany(i => i.UserItem)
            .HasForeignKey(u => u.ItemId)
            .OnDelete(DeleteBehavior.Cascade);

        modelBuilder.Entity<Category>()
            .HasKey(c => c.Id);

        modelBuilder.Entity<Category>()
            .HasMany(c => c.Tasks)
            .WithOne(t => t.Category)
            .HasForeignKey(t => t.Category_Id)
            .OnDelete(DeleteBehavior.Cascade);
    }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        optionsBuilder
            .LogTo(Console.WriteLine, LogLevel.Information)
            .EnableSensitiveDataLogging();
    }

    public DbSet<User> USERS { get; set; }
    public DbSet<Category> CATEGORIES { get; set; }
    public DbSet<ToDoTask> TASKS { get; set; }
    public DbSet<UserItem> USERITEM { get; set; }
    public DbSet<Items> ITEMS { get; set; }
}
