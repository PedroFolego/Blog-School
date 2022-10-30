namespace Auth.Models;


public class Post
{
    public int PostId { get; set; }
    public string? Title { get; set; } 
    public string Content { get; set; }
    public int  StudentId { get; set; }
    public Student? Students { get; set; }
    
};