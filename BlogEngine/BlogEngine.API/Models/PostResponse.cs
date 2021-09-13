using System;

namespace BlogEngine.API.Models
{
    public class PostResponse
    {
        public int PostId { get; set; }
        public int AuthorId { get; set; }
        public short PostStateId { get; set; }
        public string Title { get; set; }
        public string Content { get; set; }
        public DateTime? PublishingDate { get; set; }
    }
}
