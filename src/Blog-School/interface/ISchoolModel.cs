using Auth.Models;
namespace Auth.Interface;



public interface ISchoolModel
{
  public ICollection<Student> Get();

  public Student GetOne(int Id);

  public void Create(Student student);

  public void Update(Student student);

  public void Delete(int Id);


} 