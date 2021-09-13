using System;

namespace BlogEngine.Services.Models
{
    public class ApprovePostParameters
    {
        public int PostId { get; set; }

        public int AuthorId { get; set; }

        public DateTime PublishingDate { get; set; }
    }
}
