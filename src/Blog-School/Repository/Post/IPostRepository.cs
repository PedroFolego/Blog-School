using Auth.Models;

namespace Auth.Repository; 

public interface IPostRepository
{
    IEnumerable<Post> Get();

    Post? GetOne(int Id);

    void Create(Post post);

    void Update(Post post);

    void Delete(int Id);
}