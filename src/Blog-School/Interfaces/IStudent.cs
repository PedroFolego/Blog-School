using Blog.Models;

namespace Blog.Interfaces; 

public interface IStudent
{
    IEnumerable<Student> Get();

    Student? GetOne(int Id);
    Student? GetByEmail(string email);

    Student Create(Student student);

    void Update(Student student, int id);

    void Delete(int Id);
}