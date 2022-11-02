using Blog.Models;

namespace Blog.Interfaces; 

public interface IPost
{
    IEnumerable<Post> Get();

    Post? GetOne(int Id);

    void Create(Post post);

    void Update(Post post);

    void Delete(int Id);
}