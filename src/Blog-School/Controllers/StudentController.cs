using Microsoft.AspNetCore.Mvc;
using Blog.Models;
using Blog.Interfaces;
using Blog.Services;
using Microsoft.AspNetCore.Authorization;
// using System.Web.Http.Cors;

namespace Blog.Controllers;

[ApiController]
[Route("[controller]")]
public class StudentController : ControllerBase
{
  private readonly IStudent _repository;
  public StudentController(IStudent repository)
  {
    _repository = repository;
  }

  [HttpGet]
  public ActionResult Get()
  {

    var students = _repository.Get();
    return Ok(students);

  }
  [HttpGet("{id}")]
  public ActionResult GetOne(int id)
  {
    var student = _repository.GetOne(id);
    if (student == null) return NotFound();
    return Ok(student);
  }

  [HttpPost]
  public ActionResult Create(Student student)
  {
    _repository.Create(student);
    var token = Token.Generate(student);
    return Created("token", token);
  }

  [HttpPut("{id}")]
  [Authorize]
  public ActionResult Update(int id, Student student)
  {

    _repository.Update(student, id);
    return Ok(student);

  }
  [HttpDelete("{id}")]
  [Authorize]
  public ActionResult Delete(int id)
  {
    _repository.Delete(id);
    return NoContent();
  }

  // LOGIN 
  [HttpPost]
  [Route("/login")]
  public ActionResult Login(StudentLogin user)
  {
    var student = _repository.GetByEmail(user.Email);

    if (student == null || student.Password != user.Password)
    {
      return BadRequest(new { message = "Email or password invalid" });
    }
    var token = Token.Generate(student);

    return Ok(new { token = token, Name = student.Name, Username = student.Username, email = student.Email, StudentId = student.StudentId });
  }
}