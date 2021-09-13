using System.ComponentModel.DataAnnotations;

namespace BlogEngine.API.Models
{
    public class AddCommentRequest
    {
        [Required]
        public int PostId { get; set; }

        [Required]
        public string Content { get; set; }
    }
}
