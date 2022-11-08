using Blog.Interfaces;
using Blog.Models;

namespace Blog.Repository;

public class StudentRepository : IStudent
{
  protected readonly BlogContext _context;

  public StudentRepository(BlogContext context)
  {
    _context = context;
  }

    public IEnumerable<Student> Get()
    {
      return _context.Students;
    }

    public Student? GetOne(int Id)
    {
      var Student =_context.Students.FirstOrDefault(p => p.StudentId == Id);
      if (Student == null) return null;
      return Student;
    }

    public Student Create(Student student)
    {
      _context.Students.Add(student);
      _context.SaveChanges();
      return student;
    }

    public void Update(Student student, int id)
    {
      var selectStudent =_context.Students.SingleOrDefault(p => p.StudentId == id);
      selectStudent.Email = student.Email;
      selectStudent.Username = student.Username;
      selectStudent.Password = student.Password;
      selectStudent.Name = student.Name;
      _context.SaveChanges();
    }

    public void Delete(int Id)
    {
      var selectStudent =_context.Students.SingleOrDefault(p => p.StudentId == Id);

      _context.Students.Remove(selectStudent);
      _context.SaveChanges();

    }
    public Student? GetByEmail(string email) 
    {
      var student =_context.Students.FirstOrDefault(p => p.Email == email);
      return student;
    }
}