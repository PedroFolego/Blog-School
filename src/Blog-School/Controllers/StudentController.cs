using Microsoft.AspNetCore.Mvc;
using Auth.Interface;
using Auth.Models;
using Auth.Repository;

namespace Blog_School.Controllers;

[ApiController]
[Route("[controller]")]
public class SchoolController : ControllerBase
{

    private readonly IStudentRepository _repository;
    public SchoolController(IStudentRepository repository)
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
