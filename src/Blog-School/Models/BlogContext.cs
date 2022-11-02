using Microsoft.EntityFrameworkCore;
using Blog.Interfaces;

namespace Blog.Models
{
    public class BlogContext : DbContext, IBlogContext
    {
        public DbSet<Student> Students { get; set; }
        public DbSet<Post> Posts { get; set; }

        public BlogContext(DbContextOptions<BlogContext> options) : base(options) { }
        public BlogContext() { }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
                var connectionString = Environment.GetEnvironmentVariable("DOTNET_CONNECTION_STRING");

                if (connectionString == null)
                {
                    throw new InvalidOperationException("Connection string not found");
                }

                optionsBuilder.UseSqlServer(connectionString);
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
}