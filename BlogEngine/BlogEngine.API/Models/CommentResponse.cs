namespace BlogEngine.API.Models
{
    public class CommentResponse
    {
        public int CommentId { get; set; }
        public int PostId { get; set; }
        public string Content { get; set; }
        public byte State { get; set; }
    }
}
