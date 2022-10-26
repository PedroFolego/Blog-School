using Microsoft.EntityFrameworkCore;
using Auth.Models;
namespace Auth.Repository;

public interface IContext
{
    public DbSet<Post> Posts { get; set; }
    public DbSet<Student> Students { get; set; }
    public int SaveChanges();
}
