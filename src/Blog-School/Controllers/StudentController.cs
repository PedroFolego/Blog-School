using Microsoft.AspNetCore.Mvc;
using Blog.Models;
using Blog.Interfaces;
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
        return Ok(student);
    }

    [HttpPut]
    public ActionResult Update(Student student)
    {
        var validateStudent = _repository.GetOne(student.StudentId);
        if (validateStudent == null) return NotFound();

        _repository.Update(student);
        return NoContent();
    }
    [HttpDelete("{id}")]
    public ActionResult Delete(int id)
    {
        var validateStudent = _repository.GetOne(id);
        if (validateStudent == null) return NotFound();

        _repository.Delete(id);
        return NoContent();
    }
}