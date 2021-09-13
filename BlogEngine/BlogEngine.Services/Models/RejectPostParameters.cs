namespace BlogEngine.Services.Models
{
    public class RejectPostParameters
    {
        public int PostId { get; set; }

        public int AuthorId { get; set; }

        public string Message { get; set; }
    }
}
