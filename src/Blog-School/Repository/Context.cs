using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.SqlServer;
using Auth.Models;
using Auth.Repository;

public class Context : DbContext, IContext
{
    public DbSet<Post> Posts { get; set; }
    public DbSet<Student> Students { get; set; }
    public Context(DbContextOptions<Context> options) : base(options) {}

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        if (!optionsBuilder.IsConfigured)
        {
            optionsBuilder.UseSqlServer(@"
                Server=127.0.0.1;
                Database=blog_school;
                User=SA;
                Password=Password12!;
            ");
        }
    }
    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
      modelBuilder.Entity<Post>()
        .HasOne(e => e.Student)
        .WithMany(e => e.Posts)
        .HasForeignKey(e => e.StudentId);
    }
}