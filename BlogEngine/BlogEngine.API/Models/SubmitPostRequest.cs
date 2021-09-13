using System.ComponentModel.DataAnnotations;

namespace BlogEngine.API.Models
{
    public class SubmitPostRequest
    {
        [Required]
        public int PostId { get; set; }
    }
}
