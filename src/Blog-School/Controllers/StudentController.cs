using Microsoft.AspNetCore.Mvc;

namespace Blog_School.Controllers;

[ApiController]
[Route("[controller]")]
public class SchoolController : ControllerBase
{

    private readonly ISchoolModel _model;
    public SchoolController(ISchoolModel model)
    {
        _model = model;
    }

    [HttpGet]
    public IActionResult Get()
    {
        
        var students = _model.GetAll();
        return Ok(students);
        
    }
    [HttpGet("{id}")]
    public IActionResult GetOne(int id)
    {
        var student = _model.GetOne(id);
        if (student == null) return NotFound();
        return Ok(student);
    }

    [HttpPost]
    public IActionResult Create(Student student)
    {    
        _model.Create(student);
        return Ok(student);
    }

    [HttpPut]
    public IActionResult Update(Student student)
    {
        var validateStudent = _model.GetOne(student.StudentId);
        if (validateStudent == null) return NotFound();

        var newStudent = _model.Update(student);
        return Ok(newStudent);
    }
    [HttpDelete("{id}")]
    public IActionResult Delete(int id)
    {
        var validateStudent = _model.GetOne(id);
        if (validateStudent == null) return NotFound();

        _model.Delete(id);
        return NoContent();
    }
}
