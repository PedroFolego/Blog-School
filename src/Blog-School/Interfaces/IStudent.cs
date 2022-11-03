using Blog.Models;

namespace Blog.Interfaces; 

public interface IStudent
{
    IEnumerable<Student> Get();

    Student? GetOne(int Id);

    void Create(Student student);

    void Update(Student student, int id);

    void Delete(int Id);
}