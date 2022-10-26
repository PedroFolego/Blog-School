using Auth.Models;
using System.Collections.Generic;
namespace Auth.Interface;



public interface IPostModel
{
  public IEnumerable<Post> Get();

  public Post GetOne(int Id);

  public void Create(Post student);

  public void Update(Post student);

  public void Delete(int Id);

}; 