using System;

namespace BlogEngine.Services.Models
{
    public class PostResult
    {
        public int PostId { get; set; }
        public int AuthorId { get; set; }
        public short PostStateId { get; set; }
        public string Title { get; set; }
        public string Content { get; set; }
        public DateTime? PublishingDate { get; set; }
        public string Message { get; set; }
    }
}
