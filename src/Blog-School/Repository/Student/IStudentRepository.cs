using Auth.Models;

namespace Auth.Repository; 

public interface IStudentRepository
{
    IEnumerable<Student> Get();

    Student? GetOne(int Id);

    void Create(Student student);

    void Update(Student student);

    void Delete(int Id);
}