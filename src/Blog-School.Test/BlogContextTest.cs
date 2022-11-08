using Microsoft.EntityFrameworkCore;
using Blog.Models;
using Blog.Repository;
using Blog.Interfaces;

namespace Blog.Test;

public class BlogContextTest : DbContext, IBlogContext
{
  public BlogContextTest(DbContextOptions<BlogContextTest> options) : base(options)
  { }

  public DbSet<Student> Students { get; set; }
  public DbSet<Post> Posts { get; set; }

  protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
  {
    if (!optionsBuilder.IsConfigured)
    {
      optionsBuilder.UseSqlServer(@"
        Server=127.0.0.1;
        Database=blog_test;
        User=SA;
        Password=Password12;
      ");
    }
  }

}