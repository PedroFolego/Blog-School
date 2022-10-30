using Auth.Models;
using Microsoft.AspNetCore.Mvc;
namespace Auth.Interface;



public interface ISchoolModel
{
  public ICollection<Student> Get();

  public Student GetOne(int Id);

  public ActionResult Create(Student student);

  public ActionResult Update(Student student);

  public ActionResult Delete(int Id);


} 