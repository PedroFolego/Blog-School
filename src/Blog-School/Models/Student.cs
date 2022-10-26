using System.Collections.Generic;

namespace Auth.Models;



public class Student
{   
    public int StudentId { get; set; }
    public string? Name { get; set; }

    public ICollection<Post> Posts { get; set; }
}