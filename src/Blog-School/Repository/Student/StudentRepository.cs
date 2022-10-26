using Auth.Models;

namespace Auth.Repository;

public class StudentRepository : IStudentRepository 
{
  protected readonly Context _context;

  public StudentRepository(Context context)
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

    public void Create(Student student)
    {
      _context.Students.Add(student);
    }

    public void Update(Student student)
    {
      var selectStudent =_context.Students.SingleOrDefault(p => p.StudentId == student.StudentId);
      selectStudent.Name = student.Name;
      selectStudent.Posts = student.Posts;
      _context.SaveChanges();
    }

    public void Delete(int Id)
    {
      var selectStudent =_context.Students.SingleOrDefault(p => p.StudentId == Id);

      _context.Students.Remove(selectStudent);
    }
}