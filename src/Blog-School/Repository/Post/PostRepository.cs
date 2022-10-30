using Auth.Models;

namespace Auth.Repository;

public class PostRepository : IPostRepository 
{
  protected readonly Context _context;

  public PostRepository(Context context)
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
      _context.Posts.Add(post);
    }

    public void Update(Post post)
    {
      var selectPost =_context.Posts.SingleOrDefault(p => p.PostId == post.PostId);
      selectPost.Title = post.Title;
      selectPost.Content = post.Content;
      selectPost.StudentId = post.StudentId;
      selectPost.Students = post.Students;
      _context.SaveChanges();
    }

    public void Delete(int Id)
    {
      var selectPost =_context.Posts.SingleOrDefault(p => p.PostId == Id);

      _context.Posts.Remove(selectPost);
    }
}