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

}