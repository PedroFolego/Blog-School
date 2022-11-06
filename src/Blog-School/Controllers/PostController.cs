using Microsoft.AspNetCore.Mvc;
using Blog.Models;
using Blog.Interfaces;
namespace Blog.Controllers;

[ApiController]
[Route("[controller]")]
public class PostController : ControllerBase
{
    private readonly IPost _repository;
    public PostController(IPost repository)
    {
        _repository = repository;
    }

    [HttpGet]
    public IActionResult Get()
    {
        
        var posts = _repository.Get();
        return Ok(posts);
        
    }
    [HttpGet("{id}")]
    public IActionResult GetOne(int id)
    {
        var post = _repository.GetOne(id);
        if (post == null) return NotFound();
        return Ok(post);
    }

    [HttpPost]
    public IActionResult Create(Post post)
    {    
        _repository.Create(post);
        return Ok(post);
    }

    [HttpPut("{id}")]
    public IActionResult Update(int id, Post post)
    {
        var validatePost = _repository.GetOne(post.PostId);
        if (validatePost == null) return NotFound();

        _repository.Update(post, id);
        return Ok();
    }
    [HttpDelete("{id}")]
    public IActionResult Delete(int id)
    {
        var validatePost = _repository.GetOne(id);
        if (validatePost == null) return NotFound();

        _repository.Delete(id);
        return NoContent();
    }
}