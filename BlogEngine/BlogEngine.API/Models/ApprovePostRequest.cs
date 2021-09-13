using System;
using System.ComponentModel.DataAnnotations;

namespace BlogEngine.API.Models
{
    public class ApprovePostRequest
    {
        [Required]
        public int PostId { get; set; }

        [Required]
        public DateTime PublishingDate { get; set; }
    }
}
