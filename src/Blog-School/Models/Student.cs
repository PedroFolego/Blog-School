using System.Collections.Generic;

namespace Auth.Models;



public class Student
{   
    public int StudentId { get; set; }
    public string? Name { get; set; }

    public IEnumerable<Post>? Posts { get; set; }
}