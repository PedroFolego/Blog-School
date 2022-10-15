using Microsoft.AspNetCore.Mvc;
using Auth.Interface;
namespace Blog_School.Controllers;

[ApiController]
[Route("[controller]")]
public class PostController: ControllerBase
{

    private readonly IPostModel _model;
    public PostController(IPostModel model)
    {
        _model = model;
    }

    [HttpGet]
    public IActionResult Get()
    {
        
        var posts = _model.GetAll();
        return Ok(posts);
        
    }
    [HttpGet("{id}")]
    public IActionResult GetOne(int id)
    {
        var post = _model.GetOne(id);
        if (post == null) return NotFound();
        return Ok(post);
    }

    [HttpPost]
    public IActionResult Create(Post post)
    {    
        _model.Create(post);
        return Ok(post);
    }

    [HttpPut]
    public IActionResult Update(Post post)
    {
        var validatePost = _model.GetOne(post.PostId);
        if (validatePost == null) return NotFound();

        var newStudent = _model.Update(post);
        return Ok(newStudent);
    }
    [HttpDelete("{id}")]
    public IActionResult Delete(int id)
    {
        var validatePost = _model.GetOne(id);
        if (validatePost == null) return NotFound();

        _model.Delete(id);
        return NoContent();
    }
}
