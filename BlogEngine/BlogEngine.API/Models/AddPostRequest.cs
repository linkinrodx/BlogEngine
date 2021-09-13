
using System.ComponentModel.DataAnnotations;

namespace BlogEngine.API.Models
{
    public class AddPostRequest
    {
        [Required]
        public string Title { get; set; }

        [Required]
        public string Content { get; set; }
    }
}
