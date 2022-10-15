using System.Collections.Generic;

namespace Auth.Models;



public class Student
{   
    public int StundentId { get; set; }
    public string? Name { get; set; }

    public ICollection<Post> Posts { get; set; }
}