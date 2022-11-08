using Blog.Models;
using System.Collections.Generic;
namespace Blog.Test;

public static class StudentsMock
{
  public static List<Student> GetStudents() => new()
  {
    new Student { Email = "gmail@gmail.com", Password = "gmail", Name = "Gmail"},
    new Student { Email = "outlook@outlook.com", Password = "outlook", Name = "Outlook"},
  };
}