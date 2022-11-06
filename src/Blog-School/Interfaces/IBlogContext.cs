using Microsoft.EntityFrameworkCore;
using Blog.Models;
namespace Blog.Interfaces;

public interface IBlogContext
{
    public DbSet<Post> Posts { get; set; }
    public DbSet<Student> Students { get; set; }
    public int SaveChanges();
}