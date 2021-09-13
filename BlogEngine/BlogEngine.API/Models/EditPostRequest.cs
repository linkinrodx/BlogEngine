using System.ComponentModel.DataAnnotations;

namespace BlogEngine.API.Models
{
    public class EditPostRequest
    {
        [Required]
        public int PostId { get; set; }

        [Required]
        public string Title { get; set; }

        [Required]
        public string Content { get; set; }
    }
}
