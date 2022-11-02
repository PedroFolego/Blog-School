namespace Blog.Models
{
    public class Post
    {
        public int PostId { get; set; }
        public string? Content { get; set; }
        public int StudentId { get; set; }
        public Student Student { get; set; }
    }
}