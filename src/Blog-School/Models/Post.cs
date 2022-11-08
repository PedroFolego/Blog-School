namespace Blog.Models
{
    public class Post
    {
        public int PostId { get; set; }
        public string? Content { get; set; }
        public string? ImageUrl { get; set; }
        public int StudentId { get; set; }
    }
}