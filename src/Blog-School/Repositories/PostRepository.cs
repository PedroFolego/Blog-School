using Blog.Models;
using Blog.Interfaces;

namespace Blog.Repository;

public class PostRepository : IPost
{
  protected readonly BlogContext _context;

  public PostRepository(BlogContext context)
  {
    _context = context;
  }

    public IEnumerable<Post> Get()
    {
      return _context.Posts;
    }

    public Post? GetOne(int Id)
    {
      var post =_context.Posts.FirstOrDefault(p => p.PostId == Id);
      if (post == null) return null;
      return post;
    }

    public void Create(Post post)
    {
      var newPost = new Post()
      {
        StudentId = post.StudentId,
        Content = post.Content,
        ImageUrl = post.ImageUrl,
      };

      _context.Posts.Add(newPost);
      _context.SaveChanges();
    }

    public void Update(Post post, int id)
    {
      var selectPost =_context.Posts.SingleOrDefault(p => p.PostId == id);
      selectPost.ImageUrl = post.ImageUrl;
      selectPost.Content = post.Content;
      _context.SaveChanges();
    }

    public void Delete(int Id)
    {
      var selectPost =_context.Posts.SingleOrDefault(p => p.PostId == Id);

      _context.Posts.Remove(selectPost);
      _context.SaveChanges();
    }
}